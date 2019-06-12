using FreeSql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

public static class OracleConnectionExtensions {

	static Lazy<IFreeSql<OracleConnection>> _lazyOrm = new Lazy<IFreeSql<OracleConnection>>(() => new FreeSql.Oracle.OracleProvider<OracleConnection>(null , null));
	static IFreeSql<OracleConnection> _curd => _lazyOrm.Value;

	public static ISelect<T1> Select<T1>(this OracleConnection that) where T1 : class => _curd.Select<T1>().WithConnection(that);
	public static ISelect<T1> Select<T1>(this OracleConnection that, object dywhere) where T1 : class => _curd.Select<T1>(dywhere).WithConnection(that);
	public static IInsert<T1> Insert<T1>(this OracleConnection that) where T1 : class => _curd.Insert<T1>().WithConnection(that);
	public static IInsert<T1> Insert<T1>(this OracleConnection that, T1 source) where T1 : class => _curd.Insert<T1>().WithConnection(that).AppendData(source);
	public static IInsert<T1> Insert<T1>(this OracleConnection that, T1[] source) where T1 : class => _curd.Insert<T1>().WithConnection(that).AppendData(source);
	public static IInsert<T1> Insert<T1>(this OracleConnection that, IEnumerable<T1> source) where T1 : class => _curd.Insert<T1>().WithConnection(that).AppendData(source);
	public static IUpdate<T1> Update<T1>(this OracleConnection that) where T1 : class => _curd.Update<T1>().WithConnection(that);
	public static IUpdate<T1> Update<T1>(this OracleConnection that, object dywhere) where T1 : class => _curd.Update<T1>(dywhere).WithConnection(that);
	public static IDelete<T1> Delete<T1>(this OracleConnection that) where T1 : class => _curd.Delete<T1>().WithConnection(that);
	public static IDelete<T1> Delete<T1>(this OracleConnection that, object dywhere) where T1 : class => _curd.Delete<T1>(dywhere).WithConnection(that);

	public static List<T> Query<T>(this OracleConnection that, string cmdText, object parms = null) => _curd.Ado.Query<T>(that, null, cmdText, parms);
	public static List<T> Query<T>(this OracleConnection that, CommandType cmdType, string cmdText, params OracleParameter[] cmdParms) => _curd.Ado.Query<T>(that, null, cmdText, cmdParms);
}
