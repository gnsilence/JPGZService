using FreeSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

public static class SQLiteConnectionExtensions {

	static Lazy<IFreeSql<SQLiteConnection>> _lazyOrm = new Lazy<IFreeSql<SQLiteConnection>>(() => new FreeSql.Sqlite.SqliteProvider<SQLiteConnection>(null , null));
	static IFreeSql<SQLiteConnection> _curd => _lazyOrm.Value;

	public static ISelect<T1> Select<T1>(this SQLiteConnection that) where T1 : class => _curd.Select<T1>().WithConnection(that);
	public static ISelect<T1> Select<T1>(this SQLiteConnection that, object dywhere) where T1 : class => _curd.Select<T1>(dywhere).WithConnection(that);
	public static IInsert<T1> Insert<T1>(this SQLiteConnection that) where T1 : class => _curd.Insert<T1>().WithConnection(that);
	public static IInsert<T1> Insert<T1>(this SQLiteConnection that, T1 source) where T1 : class => _curd.Insert<T1>().WithConnection(that).AppendData(source);
	public static IInsert<T1> Insert<T1>(this SQLiteConnection that, T1[] source) where T1 : class => _curd.Insert<T1>().WithConnection(that).AppendData(source);
	public static IInsert<T1> Insert<T1>(this SQLiteConnection that, IEnumerable<T1> source) where T1 : class => _curd.Insert<T1>().WithConnection(that).AppendData(source);
	public static IUpdate<T1> Update<T1>(this SQLiteConnection that) where T1 : class => _curd.Update<T1>().WithConnection(that);
	public static IUpdate<T1> Update<T1>(this SQLiteConnection that, object dywhere) where T1 : class => _curd.Update<T1>(dywhere).WithConnection(that);
	public static IDelete<T1> Delete<T1>(this SQLiteConnection that) where T1 : class => _curd.Delete<T1>().WithConnection(that);
	public static IDelete<T1> Delete<T1>(this SQLiteConnection that, object dywhere) where T1 : class => _curd.Delete<T1>(dywhere).WithConnection(that);

	public static List<T> Query<T>(this SQLiteConnection that, string cmdText, object parms = null) => _curd.Ado.Query<T>(that, null, cmdText, parms);
	public static List<T> Query<T>(this SQLiteConnection that, CommandType cmdType, string cmdText, params SQLiteParameter[] cmdParms) => _curd.Ado.Query<T>(that, null, cmdText, cmdParms);
}
