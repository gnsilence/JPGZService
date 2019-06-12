using FreeSql;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;

public static class IDbConnectionExtensions {

	public static ISelect<T1> Select<T1>(this IDbConnection that) where T1 : class {
		if (that is SqlConnection) return (that as SqlConnection)?.Select<T1>();
		if (that is MySqlConnection) return (that as MySqlConnection)?.Select<T1>();
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Select<T1>();
		if (that is OracleConnection) return (that as OracleConnection)?.Select<T1>();
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Select<T1>();
		throw new NotImplementedException();
	}
	public static ISelect<T1> Select<T1>(this IDbConnection that, object dywhere) where T1 : class {
		if (that is SqlConnection) return (that as SqlConnection)?.Select<T1>(dywhere);
		if (that is MySqlConnection) return (that as MySqlConnection)?.Select<T1>(dywhere);
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Select<T1>(dywhere);
		if (that is OracleConnection) return (that as OracleConnection)?.Select<T1>(dywhere);
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Select<T1>(dywhere);
		throw new NotImplementedException();
	}
	public static IInsert<T1> Insert<T1>(this IDbConnection that) where T1 : class {
		if (that is SqlConnection) return (that as SqlConnection)?.Insert<T1>();
		if (that is MySqlConnection) return (that as MySqlConnection)?.Insert<T1>();
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Insert<T1>();
		if (that is OracleConnection) return (that as OracleConnection)?.Insert<T1>();
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Insert<T1>();
		throw new NotImplementedException();
	}
	public static IInsert<T1> Insert<T1>(this IDbConnection that, T1 source) where T1 : class {
		if (that is SqlConnection) return (that as SqlConnection)?.Insert<T1>(source);
		if (that is MySqlConnection) return (that as MySqlConnection)?.Insert<T1>(source);
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Insert<T1>(source);
		if (that is OracleConnection) return (that as OracleConnection)?.Insert<T1>(source);
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Insert<T1>(source);
		throw new NotImplementedException();
	}
	public static IInsert<T1> Insert<T1>(this IDbConnection that, T1[] source) where T1 : class {
		if (that is SqlConnection) return (that as SqlConnection)?.Insert<T1>(source);
		if (that is MySqlConnection) return (that as MySqlConnection)?.Insert<T1>(source);
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Insert<T1>(source);
		if (that is OracleConnection) return (that as OracleConnection)?.Insert<T1>(source);
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Insert<T1>(source);
		throw new NotImplementedException();
	}
	public static IInsert<T1> Insert<T1>(this IDbConnection that, IEnumerable<T1> source) where T1 : class {
		if (that is SqlConnection) return (that as SqlConnection)?.Insert<T1>(source);
		if (that is MySqlConnection) return (that as MySqlConnection)?.Insert<T1>(source);
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Insert<T1>(source);
		if (that is OracleConnection) return (that as OracleConnection)?.Insert<T1>(source);
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Insert<T1>(source);
		throw new NotImplementedException();
	}
	public static IUpdate<T1> Update<T1>(this IDbConnection that) where T1 : class {
		if (that is SqlConnection) return (that as SqlConnection)?.Update<T1>();
		if (that is MySqlConnection) return (that as MySqlConnection)?.Update<T1>();
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Update<T1>();
		if (that is OracleConnection) return (that as OracleConnection)?.Update<T1>();
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Update<T1>();
		throw new NotImplementedException();
	}
	public static IUpdate<T1> Update<T1>(this IDbConnection that, object dywhere) where T1 : class {
		if (that is SqlConnection) return (that as SqlConnection)?.Update<T1>(dywhere);
		if (that is MySqlConnection) return (that as MySqlConnection)?.Update<T1>(dywhere);
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Update<T1>(dywhere);
		if (that is OracleConnection) return (that as OracleConnection)?.Update<T1>(dywhere);
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Update<T1>(dywhere);
		throw new NotImplementedException();
	}
	public static IDelete<T1> Delete<T1>(this IDbConnection that) where T1 : class {
		if (that is SqlConnection) return (that as SqlConnection)?.Delete<T1>();
		if (that is MySqlConnection) return (that as MySqlConnection)?.Delete<T1>();
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Delete<T1>();
		if (that is OracleConnection) return (that as OracleConnection)?.Delete<T1>();
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Delete<T1>();
		throw new NotImplementedException();
	}
	public static IDelete<T1> Delete<T1>(this IDbConnection that, object dywhere) where T1 : class {
		if (that is SqlConnection) return (that as SqlConnection)?.Delete<T1>(dywhere);
		if (that is MySqlConnection) return (that as MySqlConnection)?.Delete<T1>(dywhere);
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Delete<T1>(dywhere);
		if (that is OracleConnection) return (that as OracleConnection)?.Delete<T1>(dywhere);
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Delete<T1>(dywhere);
		throw new NotImplementedException();
	}

	public static List<T> Query<T>(this IDbConnection that, string cmdText, object parms = null) {
		if (that is SqlConnection) return (that as SqlConnection)?.Query<T>(cmdText, parms);
		if (that is MySqlConnection) return (that as MySqlConnection)?.Query<T>(cmdText, parms);
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Query<T>(cmdText, parms);
		if (that is OracleConnection) return (that as OracleConnection)?.Query<T>(cmdText, parms);
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Query<T>(cmdText, parms);
		throw new NotImplementedException();
	}
	public static List<T> Query<T>(this IDbConnection that, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms) {
		if (that is SqlConnection) return (that as SqlConnection)?.Query<T>(cmdType, cmdText, cmdParms);
		if (that is MySqlConnection) return (that as MySqlConnection)?.Query<T>(cmdType, cmdText, cmdParms);
		if (that is NpgsqlConnection) return (that as NpgsqlConnection)?.Query<T>(cmdType, cmdText, cmdParms);
		if (that is OracleConnection) return (that as OracleConnection)?.Query<T>(cmdType, cmdText, cmdParms);
		if (that is SQLiteConnection) return (that as SQLiteConnection)?.Query<T>(cmdType, cmdText, cmdParms);
		throw new NotImplementedException();
	}
}
