using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Wmi;
using System.Data.Sql;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using DBMaid.ExtensionMethods;
using System.Configuration;
using System.Reflection;

namespace DBMaid
{
    public partial class FrmPincipal : Form
    {
        public FrmPincipal()
        {
            InitializeComponent();
        }
        #region Query de copiar
        string StringCopiarTabla = "DECLARE @table_name SYSNAME                                                                                                                                                             "
+ "SELECT @table_name = '{Tabla}'                                                                                                                                                     "
+ "                                                                                                                                                                                        "
+ "DECLARE                                                                                                                                                                                 "
+ "      @object_name SYSNAME                                                                                                                                                              "
+ "    , @object_id INT                                                                                                                                                                    "
+ "                                                                                                                                                                                        "
+ "SELECT                                                                                                                                                                                  "
+ "      @object_name = '[' + s.name + '].[' + o.name + ']'                                                                                                                                "
+ "    , @object_id = o.[object_id]                                                                                                                                                        "
+ "FROM sys.objects o WITH (NOWAIT)                                                                                                                                                        "
+ "JOIN sys.schemas s WITH (NOWAIT) ON o.[schema_id] = s.[schema_id]                                                                                                                       "
+ "WHERE s.name + '.' + o.name = @table_name                                                                                                                                               "
+ "    AND o.[type] = 'U'                                                                                                                                                                  "
+ "    AND o.is_ms_shipped = 0                                                                                                                                                             "
+ "                                                                                                                                                                                        "
+ "DECLARE @SQL varchar(MAX) = ''                                                                                                                                                          "
+ "DECLARE @SQL2 varchar(MAX) = ''                                                                                                                                                         "
+ "                                                                                                                                                                                        "
+ "                                                                                                                                                                                        "
+ ";WITH index_column AS                                                                                                                                                                   "
+ "(                                                                                                                                                                                       "
+ "    SELECT                                                                                                                                                                              "
+ "          ic.[object_id]                                                                                                                                                                "
+ "        , ic.index_id                                                                                                                                                                   "
+ "        , ic.is_descending_key                                                                                                                                                          "
+ "        , ic.is_included_column                                                                                                                                                         "
+ "        , c.name                                                                                                                                                                        "
+ "    FROM sys.index_columns ic WITH (NOWAIT)                                                                                                                                             "
+ "    JOIN sys.columns c WITH (NOWAIT) ON ic.[object_id] = c.[object_id] AND ic.column_id = c.column_id                                                                                   "
+ "    WHERE ic.[object_id] = @object_id                                                                                                                                                   "
+ "),                                                                                                                                                                                      "
+ "fk_columns AS                                                                                                                                                                           "
+ "(                                                                                                                                                                                       "
+ "     SELECT                                                                                                                                                                             "
+ "          k.constraint_object_id                                                                                                                                                        "
+ "        , cname = c.name                                                                                                                                                                "
+ "        , rcname = rc.name                                                                                                                                                              "
+ "    FROM sys.foreign_key_columns k WITH (NOWAIT)                                                                                                                                        "
+ "    JOIN sys.columns rc WITH (NOWAIT) ON rc.[object_id] = k.referenced_object_id AND rc.column_id = k.referenced_column_id                                                              "
+ "    JOIN sys.columns c WITH (NOWAIT) ON c.[object_id] = k.parent_object_id AND c.column_id = k.parent_column_id                                                                         "
+ "    WHERE k.parent_object_id = @object_id                                                                                                                                               "
+ ")                                                                                                                                                                                       "
+ "SELECT @SQL = '  CREATE TABLE ' + @object_name + CHAR(13) + '(' + CHAR(13) + STUFF((                                                                                                      "
+ "    SELECT CHAR(9) + ', [' + c.name + '] ' +                                                                                                                                            "
+ "        CASE WHEN c.is_computed = 1                                                                                                                                                     "
+ "            THEN 'AS ' + cc.[definition]                                                                                                                                                "
+ "            ELSE UPPER(tp.name) +                                                                                                                                                       "
+ "                CASE WHEN tp.name IN ('varchar', 'char', 'varbinary', 'binary', 'text')                                                                                                 "
+ "                       THEN '(' + CASE WHEN c.max_length = -1 THEN 'MAX' ELSE CAST(c.max_length AS VARCHAR(5)) END + ')'                                                                "
+ "                     WHEN tp.name IN ('nvarchar', 'nchar', 'ntext')                                                                                                                     "
+ "                       THEN '(' + CASE WHEN c.max_length = -1 THEN 'MAX' ELSE CAST(c.max_length / 2 AS VARCHAR(5)) END + ')'                                                            "
+ "                     WHEN tp.name IN ('datetime2', 'time2', 'datetimeoffset')                                                                                                           "
+ "                       THEN '(' + CAST(c.scale AS VARCHAR(5)) + ')'                                                                                                                     "
+ "                     WHEN tp.name = 'decimal'                                                                                                                                           "
+ "                       THEN '(' + CAST(c.[precision] AS VARCHAR(5)) + ',' + CAST(c.scale AS VARCHAR(5)) + ')'                                                                           "
+ "                    ELSE ''                                                                                                                                                             "
+ "                END +                                                                                                                                                                   "
+ "                CASE WHEN c.collation_name IS NOT NULL THEN ' COLLATE ' + c.collation_name ELSE '' END +                                                                                "
+ "                CASE WHEN c.is_nullable = 1 THEN ' NULL' ELSE ' NOT NULL' END +                                                                                                         "
+ "                CASE WHEN dc.[definition] IS NOT NULL THEN ' DEFAULT' + dc.[definition] ELSE '' END +                                                                                   "
+ "                CASE WHEN ic.is_identity = 1 THEN ' IDENTITY(' + CAST(ISNULL(ic.seed_value, '0') AS CHAR(1)) + ',' + CAST(ISNULL(ic.increment_value, '1') AS CHAR(1)) + ')' ELSE '' END "
+ "        END + CHAR(13)                                                                                                                                                                  "
+ "    FROM sys.columns c WITH (NOWAIT)                                                                                                                                                    "
+ "    JOIN sys.types tp WITH (NOWAIT) ON c.user_type_id = tp.user_type_id                                                                                                                 "
+ "    LEFT JOIN sys.computed_columns cc WITH (NOWAIT) ON c.[object_id] = cc.[object_id] AND c.column_id = cc.column_id                                                                    "
+ "    LEFT JOIN sys.default_constraints dc WITH (NOWAIT) ON c.default_object_id != 0 AND c.[object_id] = dc.parent_object_id AND c.column_id = dc.parent_column_id                        "
+ "    LEFT JOIN sys.identity_columns ic WITH (NOWAIT) ON c.is_identity = 1 AND c.[object_id] = ic.[object_id] AND c.column_id = ic.column_id                                              "
+ "    WHERE c.[object_id] = @object_id                                                                                                                                                    "
+ "    ORDER BY c.column_id                                                                                                                                                                "
+ "    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, CHAR(9) + ' ')                                                                                                           "
+ "    + ISNULL((SELECT CHAR(9) + ', CONSTRAINT [' + k.name + '] PRIMARY KEY (' +                                                                                                          "
+ "                    (SELECT STUFF((                                                                                                                                                     "
+ "                         SELECT ', [' + c.name + '] ' + CASE WHEN ic.is_descending_key = 1 THEN 'DESC' ELSE 'ASC' END                                                                   "
+ "                         FROM sys.index_columns ic WITH (NOWAIT)                                                                                                                        "
+ "                         JOIN sys.columns c WITH (NOWAIT) ON c.[object_id] = ic.[object_id] AND c.column_id = ic.column_id                                                              "
+ "                         WHERE ic.is_included_column = 0                                                                                                                                "
+ "                             AND ic.[object_id] = k.parent_object_id                                                                                                                    "
+ "                             AND ic.index_id = k.unique_index_id                                                                                                                        "
+ "                         FOR XML PATH(N''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, ''))                                                                                               "
+ "            + ')' + CHAR(13)                                                                                                                                                            "
+ "            FROM sys.key_constraints k WITH (NOWAIT)                                                                                                                                    "
+ "            WHERE k.parent_object_id = @object_id                                                                                                                                       "
+ "                AND k.[type] = 'PK'), '') + ')'  + CHAR(13)                                                                                                                             "
+ "                                                                                                                                                                                        "
+ "                                                                                                                                                                                        "
+ ";WITH index_column AS                                                                                                                                                                   "
+ "(                                                                                                                                                                                       "
+ "    SELECT                                                                                                                                                                              "
+ "          ic.[object_id]                                                                                                                                                                "
+ "        , ic.index_id                                                                                                                                                                   "
+ "        , ic.is_descending_key                                                                                                                                                          "
+ "        , ic.is_included_column                                                                                                                                                         "
+ "        , c.name                                                                                                                                                                        "
+ "    FROM sys.index_columns ic WITH (NOWAIT)                                                                                                                                             "
+ "    JOIN sys.columns c WITH (NOWAIT) ON ic.[object_id] = c.[object_id] AND ic.column_id = c.column_id                                                                                   "
+ "    WHERE ic.[object_id] = @object_id                                                                                                                                                   "
+ "),                                                                                                                                                                                      "
+ "fk_columns AS                                                                                                                                                                           "
+ "(                                                                                                                                                                                       "
+ "     SELECT                                                                                                                                                                             "
+ "          k.constraint_object_id                                                                                                                                                        "
+ "        , cname = c.name                                                                                                                                                                "
+ "        , rcname = rc.name                                                                                                                                                              "
+ "    FROM sys.foreign_key_columns k WITH (NOWAIT)                                                                                                                                        "
+ "    JOIN sys.columns rc WITH (NOWAIT) ON rc.[object_id] = k.referenced_object_id AND rc.column_id = k.referenced_column_id                                                              "
+ "    JOIN sys.columns c WITH (NOWAIT) ON c.[object_id] = k.parent_object_id AND c.column_id = k.parent_column_id                                                                         "
+ "    WHERE k.parent_object_id = @object_id                                                                                                                                               "
+ ")                                                                                                                                                                                       "
+ "SELECT @SQL2 =                                                                                                                                                                          "
+ "                                                                                                                                                                                        "
+ "    + ISNULL((SELECT (                                                                                                                                                                  "
+ "        SELECT CHAR(13) +                                                                                                                                                               "
+ "             'ALTER TABLE ' + @object_name + ' WITH'                                                                                                                                    "
+ "            + CASE WHEN fk.is_not_trusted = 1                                                                                                                                           "
+ "                THEN ' NOCHECK'                                                                                                                                                         "
+ "                ELSE ' CHECK'                                                                                                                                                           "
+ "              END +                                                                                                                                                                     "
+ "              ' ADD CONSTRAINT [' + fk.name  + '] FOREIGN KEY('                                                                                                                         "
+ "              + STUFF((                                                                                                                                                                 "
+ "                SELECT ', [' + k.cname + ']'                                                                                                                                            "
+ "                FROM fk_columns k                                                                                                                                                       "
+ "                WHERE k.constraint_object_id = fk.[object_id]                                                                                                                           "
+ "                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')                                                                                                          "
+ "               + ')' +                                                                                                                                                                  "
+ "              ' REFERENCES [' + SCHEMA_NAME(ro.[schema_id]) + '].[' + ro.name + '] ('                                                                                                   "
+ "              + STUFF((                                                                                                                                                                 "
+ "                SELECT ', [' + k.rcname + ']'                                                                                                                                           "
+ "                FROM fk_columns k                                                                                                                                                       "
+ "                WHERE k.constraint_object_id = fk.[object_id]                                                                                                                           "
+ "                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')                                                                                                          "
+ "               + ')'                                                                                                                                                                    "
+ "            + CASE                                                                                                                                                                      "
+ "                WHEN fk.delete_referential_action = 1 THEN ' ON DELETE CASCADE'                                                                                                         "
+ "                WHEN fk.delete_referential_action = 2 THEN ' ON DELETE SET NULL'                                                                                                        "
+ "                WHEN fk.delete_referential_action = 3 THEN ' ON DELETE SET DEFAULT'                                                                                                     "
+ "                ELSE ''                                                                                                                                                                 "
+ "              END                                                                                                                                                                       "
+ "            + CASE                                                                                                                                                                      "
+ "                WHEN fk.update_referential_action = 1 THEN ' ON UPDATE CASCADE'                                                                                                         "
+ "                WHEN fk.update_referential_action = 2 THEN ' ON UPDATE SET NULL'                                                                                                        "
+ "                WHEN fk.update_referential_action = 3 THEN ' ON UPDATE SET DEFAULT'                                                                                                     "
+ "                ELSE ''                                                                                                                                                                 "
+ "              END                                                                                                                                                                       "
+ "            + CHAR(13) + 'ALTER TABLE ' + @object_name + ' CHECK CONSTRAINT [' + fk.name  + ']' + CHAR(13)                                                                              "
+ "        FROM sys.foreign_keys fk WITH (NOWAIT)                                                                                                                                          "
+ "        JOIN sys.objects ro WITH (NOWAIT) ON ro.[object_id] = fk.referenced_object_id                                                                                                   "
+ "        WHERE fk.parent_object_id = @object_id                                                                                                                                          "
+ "        FOR XML PATH(N''), TYPE).value('.', 'NVARCHAR(MAX)')), '')                                                                                                                      "
+ "		+                                                                                                                                                                                 "
+ "	ISNULL(((SELECT                                                                                                                                                                       "
+ "         CHAR(13) + 'CREATE' + CASE WHEN i.is_unique = 1 THEN ' UNIQUE' ELSE '' END                                                                                                     "
+ "                + ' NONCLUSTERED INDEX [' + i.name + '] ON ' + @object_name + ' (' +                                                                                                    "
+ "                STUFF((                                                                                                                                                                 "
+ "                SELECT ', [' + c.name + ']' + CASE WHEN c.is_descending_key = 1 THEN ' DESC' ELSE ' ASC' END                                                                            "
+ "                FROM index_column c                                                                                                                                                     "
+ "                WHERE c.is_included_column = 0                                                                                                                                          "
+ "                    AND c.index_id = i.index_id                                                                                                                                         "
+ "                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') + ')'                                                                                                    "
+ "                + ISNULL(CHAR(13) + 'INCLUDE (' +                                                                                                                                       "
+ "                    STUFF((                                                                                                                                                             "
+ "                    SELECT ', [' + c.name + ']'                                                                                                                                         "
+ "                    FROM index_column c                                                                                                                                                 "
+ "                    WHERE c.is_included_column = 1                                                                                                                                      "
+ "                        AND c.index_id = i.index_id                                                                                                                                     "
+ "                    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') + ')', '')  + CHAR(13)                                                                               "
+ "        FROM sys.indexes i WITH (NOWAIT)                                                                                                                                                "
+ "        WHERE i.[object_id] = @object_id                                                                                                                                                "
+ "            AND i.is_primary_key = 0                                                                                                                                                    "
+ "            AND i.[type] = 2                                                                                                                                                            "
+ "        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)')                                                                                                                             "
+ "    ), '')                                                                                                                                                                              "
+ "                                                                                                                                                                                        "
+ "select @SQL, @SQL2                                                                                                                                                                      ";
        #endregion

        const string CADENA_CONEXION_LOCAL = "Data Source={instancia};Initial Catalog=master;Integrated Security=True";

        TreeView _tvTablasOrigen = new TreeView();
        TreeView _tvStoredOrigen = new TreeView();
        TreeView _tvVistasOrigen = new TreeView();
        TreeView _tvFuncionesOrigen = new TreeView();

        TreeView _tvTablasDestino = new TreeView();
        TreeView _tvStoredDestino = new TreeView();
        TreeView _tvVistasDestino = new TreeView();
        TreeView _tvFuncionesDestino = new TreeView();


        Dictionary<string, string> _sentenciasWhere = new Dictionary<string, string>();

        private void button5_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = txtConnStr.Text;
            cnn = new SqlConnection(connetionString);
            var csp = connetionString.Split(';');
            try
            {
                cnn.Open();
                LimpiarNodos();
                if (cnn.State == ConnectionState.Open)
                {
                    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                    var csNombre = csp.Where(x => x.ToUpper().Contains("DATA SOURCE") || x.ToUpper().Contains("SERVER")).Single().Split('=').Where(x => !(x.ToUpper().Contains("DATA SOURCE") || x.ToUpper().Contains("SERVER"))).Single();
                    config.AppSettings.Settings.Remove(csNombre);
                    config.AppSettings.Settings.Add(csNombre, connetionString);
                    config.Save(ConfigurationSaveMode.Modified);
                    //config.AppSettings.Settings.Remove("MySetting");

                    txtConnStr.Items.Clear();
                    config.AppSettings.Settings.AllKeys.ToList().ForEach(key => { txtConnStr.Items.Add(config.AppSettings.Settings[key].Value); });
                }

                //if (txtCatalog.Text == null || txtCatalog.Text.Trim().Equals(""))
                //{
                txtCatalog.Text = csp.Where(x => x.ToUpper().Contains("INITIAL CATALOG") || x.ToUpper().Contains("DATABASE")).Single().Split('=').Where(x => !(x.ToUpper().Contains("INITIAL CATALOG") || x.ToUpper().Contains("DATABASE"))).Single();
                //}

                #region Tablas
                tvTablasOrigen.Nodes.Clear();
                string queryObtenerTablas = $"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE 1=1 and  TABLE_TYPE = 'BASE TABLE'  AND  TABLE_CATALOG='{txtCatalog.Text}' order by 1,2,3 asc";
                SqlCommand command = new SqlCommand(queryObtenerTablas, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    tvTablasOrigen.Nodes.Add(dataReader.GetString(0) + "." + dataReader.GetString(1) + "." + dataReader.GetString(2));
                    _tvTablasOrigen.Nodes.Add(dataReader.GetString(0) + "." + dataReader.GetString(1) + "." + dataReader.GetString(2));
                }
                dataReader.Close();
                command.Dispose();
                #endregion
                #region Stored procedures
                tvStoredOrigen.Nodes.Clear();
                string queryObtenerStored = $"SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE'  AND  SPECIFIC_CATALOG='{txtCatalog.Text}' order by 1,2,3 asc";
                command = new SqlCommand(queryObtenerStored, cnn);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    tvStoredOrigen.Nodes.Add(dataReader.GetString(0) + "." + dataReader.GetString(1) + "." + dataReader.GetString(2));
                    _tvStoredOrigen.Nodes.Add(dataReader.GetString(0) + "." + dataReader.GetString(1) + "." + dataReader.GetString(2));
                }
                dataReader.Close();
                command.Dispose();
                #endregion
                #region Funciones
                tvFuncionesOrigen.Nodes.Clear();
                string queryObtenerFunciones = $"SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'FUNCTION'  AND  SPECIFIC_CATALOG='{txtCatalog.Text}' order by 1,2,3 asc";
                command = new SqlCommand(queryObtenerFunciones, cnn);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    tvFuncionesOrigen.Nodes.Add(dataReader.GetString(0) + "." + dataReader.GetString(1) + "." + dataReader.GetString(2));
                    _tvFuncionesOrigen.Nodes.Add(dataReader.GetString(0) + "." + dataReader.GetString(1) + "." + dataReader.GetString(2));
                }
                dataReader.Close();
                command.Dispose();
                #endregion
                #region Vistas
                tvVistasOrigen.Nodes.Clear();
                string queryObtenerVistas = $"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE 1=1 and  TABLE_TYPE = 'VIEW'  AND  TABLE_CATALOG='{txtCatalog.Text}' order by 1,2,3 asc";
                command = new SqlCommand(queryObtenerVistas, cnn);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    tvVistasOrigen.Nodes.Add(dataReader.GetString(0) + "." + dataReader.GetString(1) + "." + dataReader.GetString(2));
                    _tvVistasOrigen.Nodes.Add(dataReader.GetString(0) + "." + dataReader.GetString(1) + "." + dataReader.GetString(2));
                }
                dataReader.Close();
                command.Dispose();
                #endregion

                txtConnStr.Enabled = false;
                txtCatalog.ReadOnly = true;
                btnConectarYBuscar.Enabled = false;
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnAgregarTabla_Click(object sender, EventArgs e)
        {
            try
            {
                //var nodo = tvTablasOrigen.SelectedNode;
                //foreach (TreeNode n in tvTablasDestino.Nodes)
                //{
                //    if (n.Text == nodo.Text) return;
                //}
                tvTablasOrigen.Nodes.ToList()
                   .Where(n => n.Checked).ToList().ForEach(nodo =>
                   {
                       if (!tvTablasDestino.Nodes.ToList().Where(nd => nd.Text == nodo.Text).Any())
                       {
                           tvTablasDestino.Nodes.Add((TreeNode)nodo.Clone());
                           _tvTablasDestino.Nodes.Add((TreeNode)nodo.Clone());
                       }
                   });



            }
            catch (Exception)
            {
            }
        }

        private void btnQuitarTabla_Click(object sender, EventArgs e)
        {
            try
            {

                tvTablasDestino.Nodes.ToList()
                   .Where(n => n.Checked).ToList().ForEach(nodo =>
                   {
                       if (!tvTablasDestino.Nodes.ToList().Where(nd => nd.Text == nodo.Text).Any())
                       {
                           tvTablasDestino.Nodes.Add((TreeNode)nodo.Clone());
                           _tvTablasDestino.Nodes.Add((TreeNode)nodo.Clone());
                       }
                   });


                //var nodo = tvTablasDestino.SelectedNode;
                //tvTablasDestino.Nodes.Remove(nodo);
                //TreeNode _nodo = null;
                //foreach (TreeNode n in _tvTablasDestino.Nodes)
                //{
                //    if (n.Text == nodo.Text) { _nodo = n; break; };
                //}
                //if (_nodo != null) _tvTablasDestino.Nodes.Remove(_nodo);
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenerarScript();
        }

        private void GenerarScript()
        {
            txtScriptSQL.Text = $"-- CREAR DB \n\n if not exists(select * from sys.databases where name = '{txtCatalog.Text}') create database {txtCatalog.Text} \n GO \n\n USE [{txtCatalog.Text}] \n go \n\n";

            txtScriptSQL.AppendText("-- CREAR SCHEMAS\n\n");
            //txtScriptSQL.AppendText("IF NOT EXISTS ( SELECT  *  FROM    sys.schemas WHERE   name = N'CRPCTL' )\n EXEC('CREATE SCHEMA [CRPCTL]')\n GO\n");

            List<string> listaSchemas = new List<string>();
            foreach (TreeNode nodo in _tvTablasDestino.Nodes)
            {
                listaSchemas.Add(nodo.Text.Split('.')[1]);
            }
            listaSchemas = listaSchemas.GroupBy(x => x).Select(x => x.First()).ToList();
            listaSchemas.ForEach(sch =>
            {
                txtScriptSQL.AppendText($"IF NOT EXISTS ( SELECT  * FROM    sys.schemas WHERE   name = N'{sch}' ) \nEXEC('CREATE SCHEMA [{sch}]') \nGO\n\n");
            });

            string connetionString = null;
            SqlConnection cnn;
            connetionString = txtConnStr.Text;
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();
                #region Tablas
                //Se usa string builder xq las cadenas son inmutables y no quiero que esto use GBs de ram XD
                StringBuilder sb = new StringBuilder();
                sb.Append("");
                txtScriptSQL.AppendText("-- CREAR TABLAS\n\n");
                foreach (TreeNode nodo in _tvTablasDestino.Nodes)
                {

                    var partes = nodo.Text.Split('.');
                    string Tabla = partes[1] + "." + partes[2];
                    string queryCopiar = StringCopiarTabla.Replace("{Tabla}", Tabla);
                    SqlCommand command = new SqlCommand(queryCopiar, cnn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    txtScriptSQL.AppendText($"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{partes[1]}' AND TABLE_NAME = '{partes[2]}')\n DROP TABLE  {partes[1]}.{partes[2]} \n go \n");
                    while (dataReader.Read())
                    {
                        txtScriptSQL.AppendText(dataReader.GetString(0));
                        sb.Append(dataReader.GetString(1));
                    }
                    txtScriptSQL.AppendText("GO\n");
                    dataReader.Close();
                    command.Dispose();
                }
                txtScriptSQL.AppendText("--CREAR CONSTRAINTS \n\n");
                txtScriptSQL.AppendText(sb.ToString());
                txtScriptSQL.AppendText("GO\n");
                #endregion
                #region stored procedures
                txtScriptSQL.AppendText("-- CREAR STORED PROCEDURES\n\n");
                foreach (TreeNode nodo in _tvStoredDestino.Nodes)
                {

                    var partes = nodo.Text.Split('.');
                    string Tabla = partes[1] + "." + partes[2];
                    txtScriptSQL.AppendText($"IF EXISTS ( SELECT *  FROM INFORMATION_SCHEMA.ROUTINES where ROUTINE_TYPE = 'PROCEDURE' and SPECIFIC_NAME ='{partes[2]}' and SPECIFIC_SCHEMA ='{partes[1]}' )\n DROP PROCEDURE [{partes[1]}].[{partes[2]}] \n go\n");
                    string queryCopiar = $"sp_helptext '{Tabla}'";
                    SqlCommand command = new SqlCommand(queryCopiar, cnn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        txtScriptSQL.AppendText(dataReader.GetString(0));
                    }
                    txtScriptSQL.AppendText("GO\n");
                    dataReader.Close();
                    command.Dispose();
                }
                #endregion
                #region Funciones
                txtScriptSQL.AppendText("-- CREAR FUNCIONES\n\n");
                foreach (TreeNode nodo in _tvFuncionesDestino.Nodes)
                {

                    var partes = nodo.Text.Split('.');
                    string Tabla = partes[1] + "." + partes[2];
                    txtScriptSQL.AppendText($"IF EXISTS ( SELECT *  FROM INFORMATION_SCHEMA.ROUTINES where ROUTINE_TYPE = 'FUNCTION' and SPECIFIC_NAME ='{partes[2]}' and SPECIFIC_SCHEMA ='{partes[1]}' )\n DROP FUNCTION  [{partes[1]}].[{partes[2]}] \n go \n");
                    string queryCopiar = $"sp_helptext '{Tabla}'";
                    SqlCommand command = new SqlCommand(queryCopiar, cnn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        txtScriptSQL.AppendText(dataReader.GetString(0));
                    }
                    txtScriptSQL.AppendText("GO\n");
                    dataReader.Close();
                    command.Dispose();
                }
                #endregion
                #region Vistas
                txtScriptSQL.AppendText("-- CREAR VISTAS\n\n");
                foreach (TreeNode nodo in _tvVistasDestino.Nodes)
                {

                    var partes = nodo.Text.Split('.');
                    string Tabla = partes[1] + "." + partes[2];
                    txtScriptSQL.AppendText($"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE 1 = 1 and  TABLE_TYPE = 'VIEW' AND TABLE_CATALOG = '{partes[0]}' and TABLE_SCHEMA = '{partes[1]}' and TABLE_NAME = '{partes[2]}') \n DROP VIEW {partes[1]}.{partes[2]} \n go \n");
                    string queryCopiar = $"sp_helptext '{Tabla}'";
                    SqlCommand command = new SqlCommand(queryCopiar, cnn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        txtScriptSQL.AppendText(dataReader.GetString(0));
                    }
                    txtScriptSQL.AppendText("GO\n");
                    dataReader.Close();
                    command.Dispose();
                }
                #endregion
                cnn.Close();


                btnGuardarScript.Enabled = true;
                btnEjecutarScript.Enabled = true;
                btnBulkCopy.Enabled = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //var nodo = tvStoredOrigen.SelectedNode;
                //foreach (TreeNode n in tvStoredDestino.Nodes)
                //{
                //    if (n.Text == nodo.Text) return;
                //}
                //tvStoredDestino.Nodes.Add((TreeNode)tvStoredOrigen.SelectedNode.Clone());
                //_tvStoredDestino.Nodes.Add((TreeNode)tvStoredOrigen.SelectedNode.Clone());


                tvStoredOrigen.Nodes.ToList()
                    .Where(n => n.Checked).ToList().ForEach(nodo =>
                    {
                        if (!tvStoredDestino.Nodes.ToList().Where(nd => nd.Text == nodo.Text).Any())
                        {
                            tvStoredDestino.Nodes.Add((TreeNode)nodo.Clone());
                            _tvStoredDestino.Nodes.Add((TreeNode)nodo.Clone());
                        }
                    });
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var nodo = tvStoredDestino.SelectedNode;
                tvStoredDestino.Nodes.Remove(nodo);
                TreeNode _nodo = null;
                foreach (TreeNode n in _tvStoredDestino.Nodes)
                {
                    if (n.Text == nodo.Text) { _nodo = n; break; };
                }
                if (_nodo != null) _tvStoredDestino.Nodes.Remove(_nodo);
            }
            catch (Exception)
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //var nodo = tvVistasOrigen.SelectedNode;
                //foreach (TreeNode n in tvVistasDestino.Nodes)
                //{
                //    if (n.Text == nodo.Text) return;
                //}
                //tvVistasDestino.Nodes.Add((TreeNode)tvVistasOrigen.SelectedNode.Clone());
                //_tvVistasDestino.Nodes.Add((TreeNode)tvVistasOrigen.SelectedNode.Clone());

                tvVistasOrigen.Nodes.ToList()
                    .Where(n => n.Checked).ToList().ForEach(nodo =>
                    {
                        if (!tvVistasDestino.Nodes.ToList().Where(nd => nd.Text == nodo.Text).Any())
                        {
                            tvVistasDestino.Nodes.Add((TreeNode)nodo.Clone());
                            _tvVistasDestino.Nodes.Add((TreeNode)nodo.Clone());
                        }
                    });
            }
            catch (Exception)
            {
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var nodo = tvVistasDestino.SelectedNode;
                tvVistasDestino.Nodes.Remove(nodo);
                TreeNode _nodo = null;
                foreach (TreeNode n in _tvVistasDestino.Nodes)
                {
                    if (n.Text == nodo.Text) { _nodo = n; break; };
                }
                if (_nodo != null) _tvVistasDestino.Nodes.Remove(_nodo);
            }
            catch (Exception)
            {
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                //var nodo = tvFuncionesOrigen.SelectedNode;
                //foreach (TreeNode n in tvFuncionesDestino.Nodes)
                //{
                //    if (n.Text == nodo.Text) return;
                //}
                //tvFuncionesDestino.Nodes.Add((TreeNode)tvFuncionesOrigen.SelectedNode.Clone());
                //_tvFuncionesDestino.Nodes.Add((TreeNode)tvFuncionesOrigen.SelectedNode.Clone());

                tvFuncionesOrigen.Nodes.ToList()
                    .Where(n => n.Checked).ToList().ForEach(nodo =>
                    {
                        if (!tvFuncionesDestino.Nodes.ToList().Where(nd => nd.Text == nodo.Text).Any())
                        {
                            tvFuncionesDestino.Nodes.Add((TreeNode)nodo.Clone());
                            _tvFuncionesDestino.Nodes.Add((TreeNode)nodo.Clone());
                        }
                    });
            }
            catch (Exception)
            {
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                var nodo = tvFuncionesDestino.SelectedNode;
                tvFuncionesDestino.Nodes.Remove(nodo);
                TreeNode _nodo = null;
                foreach (TreeNode n in _tvFuncionesDestino.Nodes)
                {
                    if (n.Text == nodo.Text) { _nodo = n; break; };
                }
                if (_nodo != null) _tvFuncionesDestino.Nodes.Remove(_nodo);
            }
            catch (Exception)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "DB Maid: " + ObtenerFlavorText();
                ToolTip tooltip = new ToolTip();
                tooltip.SetToolTip(lbHelpBulk, "Es necesario que la tabla exista en la DB destino.");




                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.AllKeys.ToList().ForEach(key => { txtConnStr.Items.Add(config.AppSettings.Settings[key].Value); });




                var registryViewArray = new[] { RegistryView.Registry32, RegistryView.Registry64 };

                foreach (var registryView in registryViewArray)
                {
                    using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                    using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server"))
                    {
                        var instances = (string[])key?.GetValue("InstalledInstances");
                        if (instances != null)
                        {
                            foreach (var element in instances)
                            {
                                if (element == "MSSQLSERVER")
                                    cbDBsLocales.Items.Add(System.Environment.MachineName);
                                else
                                    cbDBsLocales.Items.Add(System.Environment.MachineName + @"\" + element);

                            }
                        }
                    }
                }
                cbDBsLocales.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ObtenerFlavorText()
        {
            string[] flavorTexts = {
                "No te metas con la 0911",
                "Also try Terraria",
                "git commit -m \"un mensaje descriptivo\"",
                "Awanten las pruebas en Producción",
                "El sexenio de AMLO termina el 30 de septiembre de 2024",
                "Los Simpson murieron en la temporada 8",
                "0.7% SSR Drop chance",
                "Xiaomi es la mejor relación calidad-precio",
                "SEKAI DE ICHIBAN OHIME-SAMA",
                "PVG 2 algún día será una realidad",
                "Ya me quiero ir",
                "Rock to the pretty girl rock, rock, rock",
                "Mamarre",
                "Pongan bachata",
                "OMAE WA MOU SHINDEIRU",
                "NANI!?",
                "Tu siguiente línea será...",
                "¿Smash Bros? Mas bien Fire Emblem Fighters",
                "タイニーリトル・アジアンタム",
                "Homura did nothing wrong",
                "https://youtu.be/dQw4w9WgXcQ",
                "Abby está bien QT uwu",
                "DORAGON SKEIRU",
                "🤔",
                "Hágame el corte de CR7",
                "Kokoro no junbi OK?",
                "Fruaido Chicken",
                "Los periodistas no deberían tener derechos",
                "Silence Journalis",
                "My name is Yoshikage Kira. I'm 33 years old. My house is in the northeast section of Morioh, where all the villas are, and I am not married. I work as an employee ...",
                "Déja Vu! I've just been in this place before",
                "Me da un peso de cilantro cuanto es?",
                "DORAGON CRO",
                "BELLI DURA DESPICIO",
                "DB Maid: DB Maid: DB Maid: DB Maid: DB Maid: DB Maid: DB Maid: DB Maid: DB Maid: DB Maid: ",
                "OwO",
                "52°28'47.1″N 62°11'08.4″E",
            };
            Random random = new Random();

            var i = random.Next(0, flavorTexts.Count());
            return flavorTexts[i];
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtConnStr.Enabled = true;
            txtCatalog.ReadOnly = false;
            btnConectarYBuscar.Enabled = true;
            LimpiarNodos();
        }

        private void LimpiarNodos()
        {
            tvFuncionesOrigen.Nodes.Clear();
            tvFuncionesDestino.Nodes.Clear();
            tvStoredDestino.Nodes.Clear();
            tvStoredOrigen.Nodes.Clear();
            tvTablasDestino.Nodes.Clear();
            tvTablasOrigen.Nodes.Clear();
            tvVistasDestino.Nodes.Clear();
            tvVistasOrigen.Nodes.Clear();

            _tvFuncionesOrigen.Nodes.Clear();
            _tvFuncionesDestino.Nodes.Clear();
            _tvStoredDestino.Nodes.Clear();
            _tvStoredOrigen.Nodes.Clear();
            _tvTablasDestino.Nodes.Clear();
            _tvTablasOrigen.Nodes.Clear();
            _tvVistasDestino.Nodes.Clear();
            _tvVistasOrigen.Nodes.Clear();

            _sentenciasWhere.Clear();
        }

        private void txtFiltroTablasOrigen_TextChanged(object sender, EventArgs e)
        {
            //blocks repainting tree till all objects loaded
            this.tvTablasOrigen.BeginUpdate();
            this.tvTablasOrigen.Nodes.Clear();
            if (this.txtFiltroTablasOrigen.Text != string.Empty)
            {
                foreach (TreeNode nodo in _tvTablasOrigen.Nodes)
                {
                    if (nodo.Text.ToUpper().Contains(this.txtFiltroTablasOrigen.Text.ToUpper()))
                    {
                        this.tvTablasOrigen.Nodes.Add((TreeNode)nodo.Clone());
                    }
                }
            }
            else
            {
                foreach (TreeNode _node in this._tvTablasOrigen.Nodes)
                {
                    tvTablasOrigen.Nodes.Add((TreeNode)_node.Clone());
                }
            }
            //enables redrawing tree after all objects have been added
            this.tvTablasOrigen.EndUpdate();
        }

        private void txtFiltroStoredOrigen_TextChanged(object sender, EventArgs e)
        {
            //blocks repainting tree till all objects loaded
            this.tvStoredOrigen.BeginUpdate();
            this.tvStoredOrigen.Nodes.Clear();
            if (this.txtFiltroStoredOrigen.Text != string.Empty)
            {
                foreach (TreeNode nodo in _tvStoredOrigen.Nodes)
                {
                    if (nodo.Text.ToUpper().Contains(this.txtFiltroStoredOrigen.Text.ToUpper()))
                    {
                        this.tvStoredOrigen.Nodes.Add((TreeNode)nodo.Clone());
                    }
                }
            }
            else
            {
                foreach (TreeNode _node in this._tvStoredOrigen.Nodes)
                {
                    tvStoredOrigen.Nodes.Add((TreeNode)_node.Clone());
                }
            }
            //enables redrawing tree after all objects have been added
            this.tvStoredOrigen.EndUpdate();
        }

        private void tvFiltroVistasOrigen_TextChanged(object sender, EventArgs e)
        {
            //blocks repainting tree till all objects loaded
            this.tvVistasOrigen.BeginUpdate();
            this.tvVistasOrigen.Nodes.Clear();
            if (this.txtFiltroVistasOrigen.Text != string.Empty)
            {
                foreach (TreeNode nodo in _tvVistasOrigen.Nodes)
                {
                    if (nodo.Text.ToUpper().Contains(this.txtFiltroVistasOrigen.Text.ToUpper()))
                    {
                        this.tvVistasOrigen.Nodes.Add((TreeNode)nodo.Clone());
                    }
                }
            }
            else
            {
                foreach (TreeNode _node in this._tvVistasOrigen.Nodes)
                {
                    tvVistasOrigen.Nodes.Add((TreeNode)_node.Clone());
                }
            }
            //enables redrawing tree after all objects have been added
            this.tvVistasOrigen.EndUpdate();
        }

        private void tvFiltroFuncionesOrigen_TextChanged(object sender, EventArgs e)
        {
            //blocks repainting tree till all objects loaded
            this.tvFuncionesOrigen.BeginUpdate();
            this.tvFuncionesOrigen.Nodes.Clear();
            if (this.txtFiltroFuncionesOrigen.Text != string.Empty)
            {
                foreach (TreeNode nodo in _tvFuncionesOrigen.Nodes)
                {
                    if (nodo.Text.ToUpper().Contains(this.txtFiltroFuncionesOrigen.Text.ToUpper()))
                    {
                        this.tvFuncionesOrigen.Nodes.Add((TreeNode)nodo.Clone());
                    }
                }
            }
            else
            {
                foreach (TreeNode _node in this._tvFuncionesOrigen.Nodes)
                {
                    tvFuncionesOrigen.Nodes.Add((TreeNode)_node.Clone());
                }
            }
            //enables redrawing tree after all objects have been added
            this.tvFuncionesOrigen.EndUpdate();
        }

        private void txtFiltroTablasDestino_TextChanged(object sender, EventArgs e)
        {
            //blocks repainting tree till all objects loaded
            this.tvTablasDestino.BeginUpdate();
            this.tvTablasDestino.Nodes.Clear();
            if (this.txtFiltroTablasDestino.Text != string.Empty)
            {
                foreach (TreeNode nodo in _tvTablasDestino.Nodes)
                {
                    if (nodo.Text.ToUpper().Contains(this.txtFiltroTablasDestino.Text.ToUpper()))
                    {
                        this.tvTablasDestino.Nodes.Add((TreeNode)nodo.Clone());
                    }
                }
            }
            else
            {
                foreach (TreeNode _node in this._tvTablasDestino.Nodes)
                {
                    tvTablasDestino.Nodes.Add((TreeNode)_node.Clone());
                }
            }
            //enables redrawing tree after all objects have been added
            this.tvTablasDestino.EndUpdate();
        }

        private void txtFiltroStoredDestino_TextChanged(object sender, EventArgs e)
        {
            //blocks repainting tree till all objects loaded
            this.tvStoredDestino.BeginUpdate();
            this.tvStoredDestino.Nodes.Clear();
            if (this.txtFiltroStoredDestino.Text != string.Empty)
            {
                foreach (TreeNode nodo in _tvStoredDestino.Nodes)
                {
                    if (nodo.Text.ToUpper().Contains(this.txtFiltroStoredDestino.Text.ToUpper()))
                    {
                        this.tvStoredDestino.Nodes.Add((TreeNode)nodo.Clone());
                    }
                }
            }
            else
            {
                foreach (TreeNode _node in this._tvStoredDestino.Nodes)
                {
                    tvStoredDestino.Nodes.Add((TreeNode)_node.Clone());
                }
            }
            //enables redrawing tree after all objects have been added
            this.tvStoredDestino.EndUpdate();
        }

        private void tvFiltroVistasDestino_TextChanged(object sender, EventArgs e)
        {
            //blocks repainting tree till all objects loaded
            this.tvVistasDestino.BeginUpdate();
            this.tvVistasDestino.Nodes.Clear();
            if (this.txtFiltroVistasDestino.Text != string.Empty)
            {
                foreach (TreeNode nodo in _tvVistasDestino.Nodes)
                {
                    if (nodo.Text.ToUpper().Contains(this.txtFiltroVistasDestino.Text.ToUpper()))
                    {
                        this.tvVistasDestino.Nodes.Add((TreeNode)nodo.Clone());
                    }
                }
            }
            else
            {
                foreach (TreeNode _node in this._tvVistasDestino.Nodes)
                {
                    tvVistasDestino.Nodes.Add((TreeNode)_node.Clone());
                }
            }
            //enables redrawing tree after all objects have been added
            this.tvVistasDestino.EndUpdate();
        }

        private void tvFiltroFuncionesDestino_TextChanged(object sender, EventArgs e)
        {
            //blocks repainting tree till all objects loaded
            this.tvFuncionesDestino.BeginUpdate();
            this.tvFuncionesDestino.Nodes.Clear();
            if (this.txtFiltroFuncionesDestino.Text != string.Empty)
            {
                foreach (TreeNode nodo in _tvFuncionesDestino.Nodes)
                {
                    if (nodo.Text.ToUpper().Contains(this.txtFiltroFuncionesDestino.Text.ToUpper()))
                    {
                        this.tvFuncionesDestino.Nodes.Add((TreeNode)nodo.Clone());
                    }
                }
            }
            else
            {
                foreach (TreeNode _node in this._tvFuncionesDestino.Nodes)
                {
                    tvFuncionesDestino.Nodes.Add((TreeNode)_node.Clone());
                }
            }
            //enables redrawing tree after all objects have been added
            this.tvFuncionesDestino.EndUpdate();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            GuardarScript();
        }

        private void GuardarScript()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Guardar sql";
            saveFileDialog1.DefaultExt = "sql";
            saveFileDialog1.Filter = "Script SQL (*.sql)|*.sql|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, txtScriptSQL.Text);
            }
        }

        private void btnEjecutarScript_Click(object sender, EventArgs e)
        {
            EjecutarScript();
        }

        private void EjecutarScript()
        {
            string connetionString = null;
            connetionString = CADENA_CONEXION_LOCAL.Replace("{instancia}", cbDBsLocales.Text);
            try
            {
                string script = txtScriptSQL.Text;
                SqlConnection conn = new SqlConnection(connetionString);
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(script);
                txtOutput.AppendText("Script ejecutado" + "\n");
                //MessageBox.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salió mal\n" + ex.Message);
            }
        }

        private void btnBulkCopy_Click(object sender, EventArgs e)
        {
            BulkCopy();
        }

        private void BulkCopy()
        {
            //MessageBox.Show
            txtOutput.AppendText
                ("Se inició el Bulk Copy. \nLa pantalla puede dejar de responder.\n");

            try
            {
                SqlConnection source = new SqlConnection(txtConnStr.Text);
                SqlConnection destination = new SqlConnection(CADENA_CONEXION_LOCAL.Replace("{instancia}", cbDBsLocales.Text));
                source.Open();
                destination.Open();
                foreach (TreeNode nodo in _tvTablasDestino.Nodes)
                {
                    var partes = nodo.Text.Split('.');
                    string Tabla = partes[0] + "." + partes[1] + "." + partes[2];
                    // Clean up destination table. 
                    string cmdDelete = "DELETE FROM " + Tabla;
                    txtOutput.AppendText("Ejecutando: " + cmdDelete + "\n");
                    var cmd = new SqlCommand(cmdDelete, destination);
                    cmd.ExecuteNonQuery();
                    //TODO: Hacer que se pueda poner un where (opcional?) para los datos

                    var where = _sentenciasWhere.Where(x => x.Key == nodo.Text).SingleOrDefault().Value;
                    if (where == null || where.Trim() == "")
                    {
                        where = "";
                    }
                    else
                    {
                        where = " where " + where;
                    }

                    string cmdSelect = "SELECT * FROM " + Tabla + where;
                    cmd = new SqlCommand(cmdSelect, source);
                    txtOutput.AppendText("Ejecutando: " + cmdSelect + "\n");
                    SqlDataReader reader = cmd.ExecuteReader();
                    // Create SqlBulkCopy
                    txtOutput.AppendText("Ejecutando bulk copy de " + Tabla + "\n");
                    SqlBulkCopy bulkData = new SqlBulkCopy(destination);
                    bulkData.BulkCopyTimeout = int.MaxValue;
                    bulkData.DestinationTableName = Tabla;
                    // Write data
                    bulkData.WriteToServer(reader);
                    txtOutput.AppendText("Bulk copy de " + Tabla + " terminado" + "\n");
                    // Close objects
                    bulkData.Close();
                    reader.Close();
                }
                destination.Close();
                source.Close();
                //MessageBox.Show
                txtOutput.AppendText
                    ("Bulk Copy terminado" + "\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salió mal\n" + ex.Message);
            }
        }

        private void txtScriptSQL_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GenerarScript();
            if (ckMostrar.Checked) txtScriptSQL.Visible = true;
            if (ckGuardar.Checked) GuardarScript();
            if (ckEjecutar.Checked) EjecutarScript();
            if (ckBulkCopy.Checked) BulkCopy();
            MessageBox.Show("Terminó la ejecución");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ambiente ambiente = new Ambiente();
            ambiente.ckBulkCopy = ckBulkCopy.Checked;
            ambiente.ckEjecutar = ckEjecutar.Checked;
            ambiente.ckGuardar = ckGuardar.Checked;
            ambiente.ckMostrar = ckMostrar.Checked;

            ambiente.tvFuncionesDestino = _tvFuncionesDestino.Nodes.ToNodeNameList();
            ambiente.tvStoredDestino = _tvStoredDestino.Nodes.ToNodeNameList();
            ambiente.tvTablasDestino = _tvTablasDestino.Nodes.ToNodeNameList();
            ambiente.tvVistasDestino = _tvVistasDestino.Nodes.ToNodeNameList();

            ambiente.sentenciasWhere = _sentenciasWhere;

            ambiente.Catalog = txtCatalog.Text;
            ambiente.Conn = txtConnStr.Text;

            var jsonSalida = JsonConvert.SerializeObject(ambiente);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Guardar ambiente";
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.Filter = "JSON (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, jsonSalida);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.DefaultExt = ".json";
            openFileDialog1.Filter = "JSON (.json)|*.json";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string ambientejson = File.ReadAllText(file);
                    Ambiente ambiente = JsonConvert.DeserializeObject<Ambiente>(ambientejson);

                    ckBulkCopy.Checked = ambiente.ckBulkCopy;
                    ckEjecutar.Checked = ambiente.ckEjecutar;
                    ckGuardar.Checked = ambiente.ckGuardar;
                    ckMostrar.Checked = ambiente.ckMostrar;

                    txtConnStr.Text = ambiente.Conn;
                    txtCatalog.Text = ambiente.Catalog;

                    button5_Click(null, null);

                    _sentenciasWhere = ambiente.sentenciasWhere;

                    foreach (string s in ambiente.tvFuncionesDestino)
                    {
                        TreeNode n = new TreeNode(s);
                        _tvFuncionesDestino.Nodes.Add((TreeNode)n.Clone());
                        tvFuncionesDestino.Nodes.Add((TreeNode)n.Clone());
                    }

                    foreach (string s in ambiente.tvTablasDestino)
                    {
                        TreeNode n = new TreeNode(s);
                        _tvTablasDestino.Nodes.Add((TreeNode)n.Clone());
                        tvTablasDestino.Nodes.Add((TreeNode)n.Clone());
                    }

                    foreach (string s in ambiente.tvVistasDestino)
                    {
                        TreeNode n = new TreeNode(s);
                        _tvVistasDestino.Nodes.Add((TreeNode)n.Clone());
                        tvVistasDestino.Nodes.Add((TreeNode)n.Clone());
                    }

                    foreach (string s in ambiente.tvStoredDestino)
                    {
                        TreeNode n = new TreeNode(s);
                        _tvStoredDestino.Nodes.Add((TreeNode)n.Clone());
                        tvStoredDestino.Nodes.Add((TreeNode)n.Clone());
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }


        }

        private void tvTablasOrigen_Click(object sender, EventArgs e)
        {
        }

        private void tvTablasOrigen_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                var nodo = tvTablasOrigen.SelectedNode;
                foreach (TreeNode n in tvTablasDestino.Nodes)
                {
                    if (n.Text == nodo.Text) return;
                }
                tvTablasDestino.Nodes.Add((TreeNode)tvTablasOrigen.SelectedNode.Clone());
                _tvTablasDestino.Nodes.Add((TreeNode)tvTablasOrigen.SelectedNode.Clone());
            }
            catch (Exception)
            {
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Text = "DB Maid: " + ObtenerFlavorText();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardarAmbienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
        }

        private void cargarAmbienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5_Click_1(null, null);
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            txtOutput.SelectionStart = txtOutput.Text.Length;
            // scroll it automatically
            txtOutput.ScrollToCaret();
        }

        private void tvTablasDestino_DoubleClick(object sender, EventArgs e)
        {
            var nodo = tvTablasDestino.SelectedNode;
            //KeyValuePair<string,string> kvpNodo = new KeyValuePair<string, string>();
            var kvp = _sentenciasWhere.Where(x => x.Key == nodo.Text).SingleOrDefault().Value;
            FrmSentenciaWhere w = new FrmSentenciaWhere(nodo, kvp ?? "");
            w.ShowDialog();
            _sentenciasWhere[nodo.Text] = w.kvp;
            //var a = 1;
        }

        private void tvStoredOrigen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var nodo = tvStoredOrigen.SelectedNode;
                foreach (TreeNode n in tvStoredDestino.Nodes)
                {
                    if (n.Text == nodo.Text) return;
                }
                tvStoredDestino.Nodes.Add((TreeNode)tvStoredOrigen.SelectedNode.Clone());
                _tvStoredDestino.Nodes.Add((TreeNode)tvStoredOrigen.SelectedNode.Clone());
            }
            catch (Exception)
            {
            }
        }

        private void tvVistasOrigen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var nodo = tvVistasOrigen.SelectedNode;
                foreach (TreeNode n in tvVistasDestino.Nodes)
                {
                    if (n.Text == nodo.Text) return;
                }
                tvVistasDestino.Nodes.Add((TreeNode)tvVistasOrigen.SelectedNode.Clone());
                _tvVistasDestino.Nodes.Add((TreeNode)tvVistasOrigen.SelectedNode.Clone());
            }
            catch (Exception)
            {
            }
        }

        private void tvFuncionesOrigen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var nodo = tvFuncionesOrigen.SelectedNode;
                foreach (TreeNode n in tvFuncionesDestino.Nodes)
                {
                    if (n.Text == nodo.Text) return;
                }
                tvFuncionesDestino.Nodes.Add((TreeNode)tvFuncionesOrigen.SelectedNode.Clone());
                _tvFuncionesDestino.Nodes.Add((TreeNode)tvFuncionesOrigen.SelectedNode.Clone());
            }
            catch (Exception)
            {
            }
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;
            return ContainsNode(node1, node2.Parent);
        }

        private void tvTablasDestino_DragDrop(object sender, DragEventArgs e)
        {
            MoverTreeNodes(sender, e, tvTablasDestino, _tvTablasDestino);
        }

        private void MoverTreeNodes(object sender, DragEventArgs e, TreeView treeview, TreeView _treeview)
        {
            Point targetPoint = treeview.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = treeview.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                if (e.Effect == DragDropEffects.Move)
                {
                    _treeview.BeginUpdate();
                    treeview.BeginUpdate();
                    var newIndex = targetNode.Index;
                    var oldIndex = draggedNode.Index;

                    var lstNodos = _treeview.Nodes.ToList();
                    lstNodos.Insert(targetNode.Index, draggedNode);
                    if (newIndex <= oldIndex) ++oldIndex;
                    lstNodos.RemoveAt(oldIndex);

                    _treeview.Nodes.Clear();
                    treeview.Nodes.Clear();

                    lstNodos.ForEach(x =>
                    {
                        _treeview.Nodes.Add((TreeNode)x.Clone());
                        treeview.Nodes.Add((TreeNode)x.Clone());
                    });
                    treeview.EndUpdate();
                    _treeview.EndUpdate();
                }
                targetNode.Expand();
            }
        }

        private void tvTablasDestino_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvTablasDestino_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvTablasDestino_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.  
            Point targetPoint = tvTablasDestino.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.  
            tvTablasDestino.SelectedNode = tvTablasDestino.GetNodeAt(targetPoint);
        }

        private void tvStoredDestino_DragDrop(object sender, DragEventArgs e)
        {
            MoverTreeNodes(sender, e, tvStoredDestino, _tvStoredDestino);
        }

        private void tvFuncionesDestino_DragDrop(object sender, DragEventArgs e)
        {
            MoverTreeNodes(sender, e, tvFuncionesDestino, _tvFuncionesDestino);
        }

        private void tvVistasDestino_DragDrop(object sender, DragEventArgs e)
        {
            MoverTreeNodes(sender, e, tvVistasDestino, _tvVistasDestino);
        }

        private void tvStoredDestino_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvFuncionesDestino_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvVistasDestino_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvStoredDestino_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = tvStoredDestino.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.  
            tvStoredDestino.SelectedNode = tvStoredDestino.GetNodeAt(targetPoint);
        }

        private void tvFuncionesDestino_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = tvFuncionesDestino.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.  
            tvFuncionesDestino.SelectedNode = tvFuncionesDestino.GetNodeAt(targetPoint);
        }

        private void tvVistasDestino_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = tvVistasDestino.PointToClient(new Point(e.X, e.Y));
            tvVistasDestino.SelectedNode = tvVistasDestino.GetNodeAt(targetPoint);
        }

        private void tvStoredDestino_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvFuncionesDestino_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvVistasDestino_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = txtConnStr.Text;
            cnn = new SqlConnection(connetionString);
            var csp = connetionString.Split(';');
            try
            {
                cnn.Open();
                LimpiarNodos();
                if (cnn.State == ConnectionState.Open)
                {
                    #region guarda la conexion
                    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                    var csNombre = csp.Where(x => x.ToUpper().Contains("DATA SOURCE") || x.ToUpper().Contains("SERVER")).Single().Split('=').Where(x => !(x.ToUpper().Contains("DATA SOURCE") || x.ToUpper().Contains("SERVER"))).Single();
                    config.AppSettings.Settings.Remove(csNombre);
                    config.AppSettings.Settings.Add(csNombre, connetionString);
                    config.Save(ConfigurationSaveMode.Modified);
                    //config.AppSettings.Settings.Remove("MySetting");

                    txtConnStr.Items.Clear();
                    config.AppSettings.Settings.AllKeys.ToList().ForEach(key => { txtConnStr.Items.Add(config.AppSettings.Settings[key].Value); });
                    #endregion
                    MessageBox.Show("😎👌 \nYEET","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("😔🔫 \n Conexion no abierta" ,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("😔🔫 \n" + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    namespace ExtensionMethods
    {
        public static class MyExtensions
        {

            public static List<TreeNode> ToList(this TreeNodeCollection nodos)
            {
                List<TreeNode> lst = new List<TreeNode>();
                foreach (TreeNode nodo in nodos)
                {
                    lst.Add(nodo);
                }
                return lst;
            }

            public static List<string> ToNodeNameList(this TreeNodeCollection nodos)
            {
                List<string> lst = new List<string>();
                foreach (TreeNode nodo in nodos)
                {
                    lst.Add(nodo.Text);
                }
                return lst;
            }

        }
    }
}

