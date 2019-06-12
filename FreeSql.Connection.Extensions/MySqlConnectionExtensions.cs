using FreeSql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public static class MySqlConnectionExtensions {

	static Lazy<IFreeSql<MySqlConnection>> _lazyOrm = new Lazy<IFreeSql<MySqlConnection>>(() => new FreeSql.MySql.MySqlProvider<MySqlConnection>(null , null));
	static IFreeSql<MySqlConnection> _curd => _lazyOrm.Value;

	public static ISelect<T1> Select<T1>(this MySqlConnection that) where T1 : class => _curd.Select<T1>().WithConnection(that);
	public static ISelect<T1> Select<T1>(this MySqlConnection that, object dywhere) where T1 : class => _curd.Select<T1>(dywhere).WithConnection(that);
	public static IInsert<T1> Insert<T1>(this MySqlConnection that) where T1 : class => _curd.Insert<T1>().WithConnection(that);
	public static IInsert<T1> Insert<T1>(this MySqlConnection that, T1 source) where T1 : class => _curd.Insert<T1>().WithConnection(that).AppendData(source);
	public static IInsert<T1> Insert<T1>(this MySqlConnection that, T1[] source) where T1 : class => _curd.Insert<T1>().WithConnection(that).AppendData(source);
	public static IInsert<T1> Insert<T1>(this MySqlConnection that, IEnumerable<T1> source) where T1 : class => _curd.Insert<T1>().WithConnection(that).AppendData(source);
	public static IUpdate<T1> Update<T1>(this MySqlConnection that) where T1 : class => _curd.Update<T1>().WithConnection(that);
	public static IUpdate<T1> Update<T1>(this MySqlConnection that, object dywhere) where T1 : class => _curd.Update<T1>(dywhere).WithConnection(that);
	public static IDelete<T1> Delete<T1>(this MySqlConnection that) where T1 : class => _curd.Delete<T1>().WithConnection(that);
	public static IDelete<T1> Delete<T1>(this MySqlConnection that, object dywhere) where T1 : class => _curd.Delete<T1>(dywhere).WithConnection(that);

	public static List<T> Query<T>(this MySqlConnection that, string cmdText, object parms = null) => _curd.Ado.Query<T>(that, null, cmdText, parms);
	public static List<T> Query<T>(this MySqlConnection that, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms) => _curd.Ado.Query<T>(that, null, cmdText, cmdParms);
}
