using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoMapper;
using AutoMapper.Configuration;
using Try1975.Nevlabs.AutoMapper;
using Try1975.Nevlabs.Dto;
using Try1975.Nevlabs.Entities;
using Try1975.Nevlabs.Logic;
using Try1975.Nevlabs.MsSql;
using Try1975.Nevlabs.QueryProcessors;

namespace Try1975.Nevlabs
{
    public partial class Form1 : Form
    {
        private readonly PersonQuery _personQuery;
        private readonly WorkContext _workContext;

        public Form1()
        {
            InitializeComponent();

            var cfg = new MapperConfigurationExpression();
            PersonAutoMapper.Configure(cfg);
            Mapper.Initialize(cfg);
            Mapper.AssertConfigurationIsValid();

            btnLoadCsv.Click += btnLoadCsv_Click;
            dgvPerson.FilterStringChanged += dgvPerson_FilterStringChanged;
            dgvPerson.SortStringChanged += dgvPerson_SortStringChanged;

            _workContext = new WorkContext();
            _personQuery = new PersonQuery(_workContext);
            var list = _personQuery.GetEntities();
            RefreshData(Mapper.Map<List<PersonDto>>(list));
        }


        #region RefreshData

        private void RefreshData(IEnumerable<PersonDto> list)
        {
            var dataTable = ConvertToDataTable(list);
            dataTable.RowChanged += Row_Changed;
            bsPerson.DataSource = dataTable;
            dgvPerson.DataSource = bsPerson;
            ColumnSettings(dgvPerson);
        }
        private void RefreshData()
        {
            var list = _personQuery.GetEntities();
            RefreshData(Mapper.Map<List<PersonDto>>(list));
        }

        private void ColumnSettings(DataGridView dgv)
        {
            var column = dgv.Columns[nameof(PersonDto.Id)];
            if (column != null)
            {
                column.ReadOnly = true;
            }
        }

        private void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            Debug.WriteLine($"Row_Changed Event: row={e.Row.RowState}; action={e.Action}");
            if (e.Row.RowState != DataRowState.Added || e.Action != DataRowAction.Change)
            {
                return;
            }
            try
            {
                var dto = new PersonDto
                {
                    Fullname = $"{e.Row[nameof(PersonDto.Fullname)]}",
                    Birthday = $"{e.Row[nameof(PersonDto.Birthday)]}",
                    Email = $"{e.Row[nameof(PersonDto.Email)]}",
                    Phone = $"{e.Row[nameof(PersonDto.Phone)]}",
                    Id = Convert.ToInt32($"{e.Row[nameof(PersonDto.Id)]}")
                };
                var entity = Mapper.Map<PersonEntity>(dto);
                _personQuery.UpdateEntity(entity);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                //throw;
            }

        }


        #endregion //RefreshData

        #region EventHandlers

        private void dgvPerson_SortStringChanged(object sender, EventArgs e)
        {
            SortStringChanged(bsPerson, dgvPerson.SortString);
        }

        private void dgvPerson_FilterStringChanged(object sender, EventArgs e)
        {
            FilterStringChanged(bsPerson, dgvPerson.FilterString);
        }

        private void btnLoadCsv_Click(object sender, EventArgs e)
        {
            LoadCsv();
        }

        #endregion //EventHandlers

        #region Logic

        private void LoadCsv()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var csvSplitter = "\t";
            try
            {
                csvSplitter = ConfigurationManager.AppSettings["CsvSplitter"];
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                //throw;
            }
            var list = ReadPersonDtosFromCsv(openFileDialog.FileName, cbSkipHeader.Checked, new[] { csvSplitter })
                .ToList();
            var dataTable = ConvertToDataTable(list);
            SqlBulkLoad(Constants.CreateTableName(nameof(_workContext.Persons)), dataTable);
            RefreshData();
        }

        private void SqlBulkLoad(string destinationTableName, DataTable dataTable)
        {
            using (var bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["NevLabs"].ConnectionString))
            {
                bulkCopy.DestinationTableName = destinationTableName;
                //mapping 
                bulkCopy.ColumnMappings.Clear();
                for (var j = 0; j < dataTable.Columns.Count; j++)
                {
                    var columnName = dataTable.Columns[j].ColumnName;
                    var map = Mapper.Configuration.FindTypeMapFor<PersonEntity, PersonDto>();
                    var propertyMap = map.GetPropertyMaps()
                        .First(pm => pm.SourceMember == typeof(PersonEntity).GetProperty(columnName));

                    if (propertyMap != null)
                        bulkCopy.ColumnMappings.Add(columnName, propertyMap.DestinationProperty.Name);
                }

                bulkCopy.WriteToServer(dataTable); // Bulk Copy to SQL Server 
            }
        }

        #endregion //Logic

        #region StaticMethods

        private static void SortStringChanged(BindingSource bindingSource, string sortString)
        {
            bindingSource.Sort = sortString;
        }

        private static void FilterStringChanged(BindingSource bindingSource, string filterString)
        {
            bindingSource.Filter = filterString;
        }

        private static DataTable ConvertToDataTable<T>(IEnumerable<T> data)
        {
            var properties =
                TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private static IEnumerable<PersonDto> ReadPersonDtosFromCsv(string fullPath, bool skipHeader, string[] csvSplitter)
        {
            var list = new List<PersonDto>();
            // read from scv to list
            try
            {
                list = File.ReadAllLines(fullPath, Encoding.Default)
                    .Skip(skipHeader ? 1 : 0)
                    .Select(z => PersonDto.FromCsv(z, csvSplitter))
                    .ToList();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                //throw;
            }
            return list;
        }

        #endregion //StaticMethods
    }
}