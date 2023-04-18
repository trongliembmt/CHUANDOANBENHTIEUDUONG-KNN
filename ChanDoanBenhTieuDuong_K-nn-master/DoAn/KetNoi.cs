using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    class KetNoi
    {
        public SqlConnection connsql;
        public SqlConnection conn;

        public void ketNoiUser()
        {
            connsql = DangNhapSQL.connsql;
        }

        public void moKetNoi()
        {
            if (connsql.State == ConnectionState.Closed)
            {
                connsql.Open();
            }
        }

        public void dongKetNoi()
        {
            if (connsql.State == ConnectionState.Open)
            {
                connsql.Close();
            }
        }
    }
}
