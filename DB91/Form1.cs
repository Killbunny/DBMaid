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

namespace DB91
{
    public partial class Form1 : Form
    {
        public Form1()
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

        TreeView _tvTablasOrigen = new TreeView();
        TreeView _tvStoredOrigen = new TreeView();
        TreeView _tvVistasOrigen = new TreeView();
        TreeView _tvFuncionesOrigen = new TreeView();

        TreeView _tvTablasDestino = new TreeView();
        TreeView _tvStoredDestino = new TreeView();
        TreeView _tvVistasDestino = new TreeView();
        TreeView _tvFuncionesDestino = new TreeView();

        private void button5_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = txtConnStr.Text;
            cnn = new SqlConnection(connetionString);



            try
            {
                cnn.Open();
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

                txtConnStr.ReadOnly = true;
                txtCatalog.ReadOnly = true;
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }

        }

        private void btnAgregarTabla_Click(object sender, EventArgs e)
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

        private void btnQuitarTabla_Click(object sender, EventArgs e)
        {
            try
            {
                var nodo = tvTablasDestino.SelectedNode;
                tvTablasDestino.Nodes.Remove(nodo);
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtScriptSQL.Text = $"-- CREAR DB \n\n if not exists(select * from sys.databases where name = '{txtCatalog.Text}') create database {txtCatalog.Text} \n GO \n\n USE [{txtCatalog.Text}] \n go \n\n";

            txtScriptSQL.AppendText("-- CREAR SCHEMAS\n\n");
            txtScriptSQL.AppendText("IF NOT EXISTS ( SELECT  *  FROM    sys.schemas WHERE   name = N'CRPCTL' )\n EXEC('CREATE SCHEMA [CRPCTL]')\n GO\n");
            txtScriptSQL.AppendText("IF NOT EXISTS ( SELECT  * FROM    sys.schemas WHERE   name = N'CRPDTA' ) \nEXEC('CREATE SCHEMA [CRPDTA]') \nGO\n\n");
            string connetionString = null;
            SqlConnection cnn;
            connetionString = txtConnStr.Text;
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();
                #region Tablas
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
                        txtScriptSQL.AppendText(dataReader.GetString(1));
                    }
                    txtScriptSQL.AppendText("GO\n");
                    dataReader.Close();
                    command.Dispose();
                }
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
                cnn.Close();


                btnGuardarScript.Enabled = true;
                btnEjecutarScript.Enabled = true;
            }
            catch (Exception)
            {

                throw;
            }
        }






        private void button4_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var nodo = tvStoredDestino.SelectedNode;
                tvStoredDestino.Nodes.Remove(nodo);
            }
            catch (Exception)
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var nodo = tvVistasDestino.SelectedNode;
                tvVistasDestino.Nodes.Remove(nodo);
            }
            catch (Exception)
            {
            }
        }

        private void button9_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                var nodo = tvFuncionesDestino.SelectedNode;
                tvFuncionesDestino.Nodes.Remove(nodo);
            }
            catch (Exception)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //cbDBsLocales.Items.Clear();
                //SqlDataSourceEnumerator instance2 = SqlDataSourceEnumerator.Instance;
                //System.Data.DataTable table2 = instance2.GetDataSources();
                //foreach (System.Data.DataRow row in table2.Rows)
                //{
                //    //if (row["ServerName"] != DBNull.Value && Environment.MachineName.Equals(row["ServerName"].ToString()))
                //    //{
                //    string item = string.Empty;
                //    item = row["ServerName"].ToString();
                //    if (row["InstanceName"] != DBNull.Value || !string.IsNullOrEmpty(Convert.ToString(row["InstanceName"]).Trim()))
                //    {
                //        item += @"\" + Convert.ToString(row["InstanceName"]).Trim();
                //    }
                //    cbDBsLocales.Items.Add(item);
                //    //}
                //}


                //using (DataTable sqlSources = SqlDataSourceEnumerator.Instance.GetDataSources())
                //{
                //    foreach (DataRow source in sqlSources.Rows)
                //    {
                //        string servername;
                //        string instanceName = source["InstanceName"].ToString();

                //        if (!string.IsNullOrEmpty(instanceName))
                //        {
                //            servername = source["InstanceName"] + "\\" + source["ServerName"];
                //        }
                //        else
                //        {
                //            servername = source["ServerName"].ToString();
                //        }
                //        Console.WriteLine(" Server Name:{0}", servername);
                //        Console.WriteLine("     Version:{0}", source["Version"]);
                //        Console.WriteLine();
                //        cbDBsLocales.Items.Add(servername);

                //    }
                //    //Console.ReadKey();
                //}



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtConnStr.ReadOnly = false;
            txtCatalog.ReadOnly = false;
            tvFuncionesOrigen.Nodes.Clear();
            tvFuncionesDestino.Nodes.Clear();
            tvStoredDestino.Nodes.Clear();
            tvStoredOrigen.Nodes.Clear();
            tvTablasDestino.Nodes.Clear();
            tvTablasOrigen.Nodes.Clear();
            tvVistasDestino.Nodes.Clear();
            tvVistasOrigen.Nodes.Clear();

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
            string connetionString = null;
            SqlConnection cnn;
            connetionString = txtConStrDestino.Text;
            try
            {
                string script = txtScriptSQL.Text;
                SqlConnection conn = new SqlConnection(connetionString);
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(script);
                MessageBox.Show("Script ejecutado uwu");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salió mal :( \n" + ex.Message);
            }
        }
    }
}

