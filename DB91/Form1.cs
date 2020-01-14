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

namespace DB91
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
                }
                dataReader.Close();
                command.Dispose();
                #endregion


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
                tvTablasOrigen.Nodes.Remove(nodo);
                tvTablasDestino.Nodes.Add(nodo);
                //tvOrigen.Sort();
                //tvDestino.Sort();
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
                tvTablasOrigen.Nodes.Add(nodo);
                //tvOrigen.Sort();
                //tvDestino.Sort();
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtScriptSQL.Text = "";
            string connetionString = null;
            SqlConnection cnn;
            connetionString = txtConnStr.Text;
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();
                #region Tablas
                foreach (TreeNode nodo in tvTablasDestino.Nodes)
                {

                    var partes = nodo.Text.Split('.');
                    string Tabla = partes[1] + "." + partes[2];
                    string queryCopiar = StringCopiarTabla.Replace("{Tabla}", Tabla);
                    SqlCommand command = new SqlCommand(queryCopiar, cnn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        txtScriptSQL.AppendText(dataReader.GetString(0));
                        txtScriptSQL.AppendText(dataReader.GetString(1));
                    }
                    dataReader.Close();
                    command.Dispose();
                }
                #endregion

                #region stored procedures
                foreach (TreeNode nodo in tvStoredDestino.Nodes)
                {

                    var partes = nodo.Text.Split('.');
                    string Tabla = partes[1] + "." + partes[2];
                    string queryCopiar = $"sp_helptext '{Tabla}'";
                    SqlCommand command = new SqlCommand(queryCopiar, cnn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        txtScriptSQL.AppendText(dataReader.GetString(0));
                    }
                    dataReader.Close();
                    command.Dispose();
                }
                #endregion

                #region Vistas
                foreach (TreeNode nodo in tvVistasDestino.Nodes)
                {

                    var partes = nodo.Text.Split('.');
                    string Tabla = partes[1] + "." + partes[2];
                    string queryCopiar = $"sp_helptext '{Tabla}'";
                    SqlCommand command = new SqlCommand(queryCopiar, cnn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        txtScriptSQL.AppendText(dataReader.GetString(0));
                    }
                    dataReader.Close();
                    command.Dispose();
                }
                #endregion

                #region Funciones
                foreach (TreeNode nodo in tvFuncionesDestino.Nodes)
                {

                    var partes = nodo.Text.Split('.');
                    string Tabla = partes[1] + "." + partes[2];
                    string queryCopiar = $"sp_helptext '{Tabla}'";
                    SqlCommand command = new SqlCommand(queryCopiar, cnn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        txtScriptSQL.AppendText(dataReader.GetString(0));
                    }
                    dataReader.Close();
                    command.Dispose();
                }
                #endregion
                cnn.Close();
            }
            catch (Exception)
            {

                throw;
            }
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
+ "SELECT @SQL = 'CREATE TABLE ' + @object_name + CHAR(13) + '(' + CHAR(13) + STUFF((                                                                                                      "
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var nodo = tvStoredOrigen.SelectedNode;
                tvStoredOrigen.Nodes.Remove(nodo);
                tvStoredDestino.Nodes.Add(nodo);
                //tvOrigen.Sort();
                //tvDestino.Sort();
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
                tvStoredOrigen.Nodes.Add(nodo);
                //tvOrigen.Sort();
                //tvDestino.Sort();
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
                tvVistasOrigen.Nodes.Remove(nodo);
                tvVistasDestino.Nodes.Add(nodo);
                //tvOrigen.Sort();
                //tvDestino.Sort();
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
                tvVistasOrigen.Nodes.Add(nodo);
                //tvOrigen.Sort();
                //tvDestino.Sort();
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
                tvFuncionesOrigen.Nodes.Remove(nodo);
                tvFuncionesDestino.Nodes.Add(nodo);
                //tvOrigen.Sort();
                //tvDestino.Sort();
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
                tvFuncionesOrigen.Nodes.Add(nodo);
                //tvOrigen.Sort();
                //tvDestino.Sort() ;
            }
            catch (Exception)
            {
            }
        }
    }
}
