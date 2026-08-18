using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DbConnection
{
    public class DbCon : IDisposable
    {
        #region Field

        private SqlConnection _conn;
        private SqlCommand _cmd;
        private SqlTransaction _tran;

        private bool disposedValue;

        #endregion

         /*
        =========================================================
            DbCon 사용 예제

            // Stored Procedure 실행
            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_Board_Select");

                db.AddParameter("@BoardNo", 1);

                DataTable dt = db.ExecuteDataTable();
            }

            // SQL 실행
            using (DbCon db = new DbCon())
            {
                db.SetQuery("SELECT * FROM Board");

                DataTable dt = db.ExecuteDataTable();
            }

            // INSERT / UPDATE / DELETE
            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_Board_Insert");

                db.AddParameter("@Title", "제목");
                db.AddParameter("@Writer", "홍길동");

                db.ExecuteNonQuery();
            }

            // COUNT, MAX 등 단일 값 조회
            using (DbCon db = new DbCon())
            {
                db.SetStoredProcedure("up_Board_Count");

                int count = Convert.ToInt32(db.ExecuteScalar());
            }

        =========================================================
        */

        #region Constructor

        public DbCon()
        {
            _conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["BOARD"].ConnectionString);

            _conn.Open();
        }

        #endregion

        #region StoredProcedure

        public void SetStoredProcedure(string spName)
        {
            _cmd = new SqlCommand(spName, _conn);
            _cmd.CommandType = CommandType.StoredProcedure;

            if (_tran != null)
                _cmd.Transaction = _tran;
        }

        #endregion

        #region Query

        public void SetQuery(string sql)
        {
            _cmd = new SqlCommand(sql, _conn);
            _cmd.CommandType = CommandType.Text;

            if (_tran != null)
                _cmd.Transaction = _tran;
        }

        #endregion

        #region Parameter

        public void AddParameter(string name, object value)
        {
            _cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);
        }

        #endregion

        #region Execute

        public int ExecuteNonQuery()
        {
            return _cmd.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            return _cmd.ExecuteScalar();
        }

        public SqlDataReader ExecuteReader()
        {
            return _cmd.ExecuteReader();
        }

        public DataTable ExecuteDataTable()
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(_cmd))
            {
                da.Fill(dt);
            }

            return dt;
        }

        #endregion

        #region Transaction

        public void BeginTransaction()
        {
            _tran = _conn.BeginTransaction();

            if (_cmd != null)
                _cmd.Transaction = _tran;
        }

        public void Commit()
        {
            _tran?.Commit();
        }

        public void Rollback()
        {
            _tran?.Rollback();
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_cmd != null)
                    {
                        _cmd.Dispose();
                        _cmd = null;
                    }

                    if (_tran != null)
                    {
                        _tran.Dispose();
                        _tran = null;
                    }

                    if (_conn != null)
                    {
                        if (_conn.State != ConnectionState.Closed)
                            _conn.Close();

                        _conn.Dispose();
                        _conn = null;
                    }
                }

                disposedValue = true;
            }
        }

        // 필요 시 비관리 리소스가 있을 경우 사용
        // ~DbCon()
        // {
        //     Dispose(false);
        // }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}