﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Domains.Repositories;

namespace Util.Datas.Sql.Queries {
    /// <summary>
    /// Sql生成器
    /// </summary>
    public interface ISqlBuilder : ICondition {
        /// <summary>
        /// 复制Sql生成器
        /// </summary>
        ISqlBuilder Clone();
        /// <summary>
        /// 创建一个新的Sql生成器
        /// </summary>
        ISqlBuilder New();
        /// <summary>
        /// 清空并初始化
        /// </summary>
        void Clear();
        /// <summary>
        /// 清空Select子句
        /// </summary>
        void ClearSelect();
        /// <summary>
        /// 清空From子句
        /// </summary>
        void ClearFrom();
        /// <summary>
        /// 清空Join子句
        /// </summary>
        void ClearJoin();
        /// <summary>
        /// 清空Where子句
        /// </summary>
        void ClearWhere();
        /// <summary>
        /// 清空GroupBy子句
        /// </summary>
        void ClearGroupBy();
        /// <summary>
        /// 清空OrderBy子句
        /// </summary>
        void ClearOrderBy();
        /// <summary>
        /// 清空Sql参数
        /// </summary>
        void ClearSqlParams();
        /// <summary>
        /// 清空分页参数
        /// </summary>
        void ClearPageParams();
        /// <summary>
        /// 获取Select语句
        /// </summary>
        string GetSelect();
        /// <summary>
        /// 获取From语句
        /// </summary>
        string GetFrom();
        /// <summary>
        /// 获取Join语句
        /// </summary>
        string GetJoin();
        /// <summary>
        /// 获取Where语句
        /// </summary>
        string GetWhere();
        /// <summary>
        /// 获取分组语句
        /// </summary>
        string GetGroupBy();
        /// <summary>
        /// 获取排序语句
        /// </summary>
        string GetOrderBy();
        /// <summary>
        /// 生成调试Sql语句，Sql语句中的参数被替换为参数值
        /// </summary>
        string ToDebugSql();
        /// <summary>
        /// 生成Sql语句
        /// </summary>
        string ToSql();
        /// <summary>
        /// 添加Sql参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        void AddParam( string name, object value );
        /// <summary>
        /// 获取Sql参数列表
        /// </summary>
        IReadOnlyDictionary<string, object> GetParams();
        /// <summary>
        /// 过滤重复记录
        /// </summary>
        ISqlBuilder Distinct();
        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Count( string columnAlias = null );
        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Count( string column, string columnAlias );
        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Count<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Sum( string column, string columnAlias = null );
        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Sum<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Avg( string column, string columnAlias = null );
        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Avg<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Max( string column, string columnAlias = null );
        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Max<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Min( string column, string columnAlias = null );
        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Min<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名,范例：a.AppId As Id,a.Name</param>
        /// <param name="tableAlias">表别名</param>
        ISqlBuilder Select( string columns, string tableAlias = null );
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名,范例：t => new object[] { t.Id, t.Name }</param>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        ISqlBuilder Select<TEntity>( Expression<Func<TEntity, object[]>> columns, bool propertyAsAlias = false ) where TEntity : class;
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="column">列名,范例：t => t.Name，支持字典批量设置列和列别名，
        /// 范例：Select&lt;Sample&gt;( t => new Dictionary&lt;object, string&gt; { { t.Email, "e" }, { t.Url, "u" } } );</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder Select<TEntity>( Expression<Func<TEntity, object>> column, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        ISqlBuilder AppendSelect( string sql );
        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder AppendSelect( ISqlBuilder builder, string columnAlias );
        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="columnAlias">列别名</param>
        ISqlBuilder AppendSelect( Action<ISqlBuilder> action, string columnAlias );
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        ISqlBuilder From( string table, string alias = null );
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        ISqlBuilder From<TEntity>( string alias = null, string schema = null ) where TEntity : class;
        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        ISqlBuilder AppendFrom( string sql );
        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        ISqlBuilder AppendFrom( ISqlBuilder builder, string alias );
        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        ISqlBuilder AppendFrom( Action<ISqlBuilder> action, string alias );
        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        ISqlBuilder Join( string table, string alias = null );
        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        ISqlBuilder Join<TEntity>( string alias = null, string schema = null ) where TEntity : class;
        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        ISqlBuilder AppendJoin( string sql );
        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        ISqlBuilder AppendJoin( ISqlBuilder builder, string alias );
        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        ISqlBuilder AppendJoin( Action<ISqlBuilder> action, string alias );
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        ISqlBuilder LeftJoin( string table, string alias = null );
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        ISqlBuilder LeftJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class;
        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        ISqlBuilder AppendLeftJoin( string sql );
        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        ISqlBuilder AppendLeftJoin( ISqlBuilder builder, string alias );
        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        ISqlBuilder AppendLeftJoin( Action<ISqlBuilder> action, string alias );
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        ISqlBuilder RightJoin( string table, string alias = null );
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        ISqlBuilder RightJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class;
        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        ISqlBuilder AppendRightJoin( string sql );
        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        ISqlBuilder AppendRightJoin( ISqlBuilder builder, string alias );
        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        ISqlBuilder AppendRightJoin( Action<ISqlBuilder> action, string alias );
        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        ISqlBuilder On( string left, string right, Operator @operator = Operator.Equal );
        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名,范例：t => t.Name</param>
        /// <param name="right">右表列名,范例：t => t.Name</param>
        /// <param name="operator">条件运算符</param>
        ISqlBuilder On<TLeft, TRight>( Expression<Func<TLeft, object>> left, Expression<Func<TRight, object>> right, Operator @operator = Operator.Equal ) where TLeft : class where TRight : class;
        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="expression">条件表达式,范例：(l,r) => l.Id == r.OrderId</param>
        ISqlBuilder On<TLeft, TRight>( Expression<Func<TLeft, TRight, bool>> expression ) where TLeft : class where TRight : class;
        /// <summary>
        /// And连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        ISqlBuilder And( ICondition condition );
        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        ISqlBuilder Or( ICondition condition );
        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="conditions">查询条件</param>
        ISqlBuilder Or<TEntity>( params Expression<Func<TEntity, bool>>[] conditions );
        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="conditions">查询条件,如果表达式中的值为空，则忽略该查询条件</param>
        ISqlBuilder OrIfNotEmpty<TEntity>( params Expression<Func<TEntity, bool>>[] conditions );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        ISqlBuilder Where( ICondition condition );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        ISqlBuilder Where( string column, object value, Operator @operator = Operator.Equal );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        ISqlBuilder Where<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式,范例：t => t.Name.Contains("a") &amp;&amp; ( t.Code == "b" || t.Age > 1 )</param>
        ISqlBuilder Where<TEntity>( Expression<Func<TEntity, bool>> expression ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        ISqlBuilder WhereIf( string column, object value, bool condition, Operator @operator = Operator.Equal );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        ISqlBuilder WhereIf<TEntity>( Expression<Func<TEntity, object>> expression, object value, bool condition, Operator @operator = Operator.Equal ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式,范例：t => t.Name.Contains("a") &amp;&amp; ( t.Code == "b" || t.Age > 1 )</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        ISqlBuilder WhereIf<TEntity>( Expression<Func<TEntity, bool>> expression, bool condition ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        ISqlBuilder WhereIfNotEmpty( string column, object value, Operator @operator = Operator.Equal );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        ISqlBuilder WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式,如果参数值为空，则忽略该查询条件</param>
        ISqlBuilder WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, bool>> expression ) where TEntity : class;
        /// <summary>
        /// 添加到Where子句
        /// </summary>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        ISqlBuilder AppendWhere( string sql );
        /// <summary>
        /// 设置相等查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        ISqlBuilder Equal( string column, object value );
        /// <summary>
        /// 设置相等查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        ISqlBuilder Equal<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class;
        /// <summary>
        /// 设置不相等查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        ISqlBuilder NotEqual( string column, object value );
        /// <summary>
        /// 设置不相等查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        ISqlBuilder NotEqual<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class;
        /// <summary>
        /// 设置大于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        ISqlBuilder Greater( string column, object value );
        /// <summary>
        /// 设置大于查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        ISqlBuilder Greater<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class;
        /// <summary>
        /// 设置小于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        ISqlBuilder Less( string column, object value );
        /// <summary>
        /// 设置小于查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        ISqlBuilder Less<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class;
        /// <summary>
        /// 设置大于等于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        ISqlBuilder GreaterEqual( string column, object value );
        /// <summary>
        /// 设置大于等于查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        ISqlBuilder GreaterEqual<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class;
        /// <summary>
        /// 设置小于等于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        ISqlBuilder LessEqual( string column, object value );
        /// <summary>
        /// 设置小于等于查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        ISqlBuilder LessEqual<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class;
        /// <summary>
        /// 设置模糊匹配查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        ISqlBuilder Contains( string column, object value );
        /// <summary>
        /// 设置模糊匹配查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        ISqlBuilder Contains<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class;
        /// <summary>
        /// 设置头匹配查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        ISqlBuilder Starts( string column, object value );
        /// <summary>
        /// 设置头匹配查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        ISqlBuilder Starts<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class;
        /// <summary>
        /// 设置尾匹配查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        ISqlBuilder Ends( string column, object value );
        /// <summary>
        /// 设置尾匹配查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        ISqlBuilder Ends<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class;
        /// <summary>
        /// 设置Is Null查询条件
        /// </summary>
        /// <param name="column">列名</param>
        ISqlBuilder IsNull( string column );
        /// <summary>
        /// 设置Is Null查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        ISqlBuilder IsNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class;
        /// <summary>
        /// 设置Is Not Null查询条件
        /// </summary>
        /// <param name="column">列名</param>
        ISqlBuilder IsNotNull( string column );
        /// <summary>
        /// 设置Is Not Null查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        ISqlBuilder IsNotNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class;
        /// <summary>
        /// 设置空条件，范例：[Name] Is Null Or [Name]=''
        /// </summary>
        /// <param name="column">列名</param>
        ISqlBuilder IsEmpty( string column );
        /// <summary>
        /// 设置空条件，范例：[Name] Is Null Or [Name]=''
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        ISqlBuilder IsEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class;
        /// <summary>
        /// 设置非空条件，范例：[Name] Is Not Null And [Name]&lt;&gt;''
        /// </summary>
        /// <param name="column">列名</param>
        ISqlBuilder IsNotEmpty( string column );
        /// <summary>
        /// 设置非空条件，范例：[Name] Is Not Null And [Name]&lt;&gt;''
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        ISqlBuilder IsNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class;
        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        ISqlBuilder In( string column, IEnumerable<object> values );
        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="values">值集合</param>
        ISqlBuilder In<TEntity>( Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class;
        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        ISqlBuilder NotIn( string column, IEnumerable<object> values );
        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="values">值集合</param>
        ISqlBuilder NotIn<TEntity>( Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class;
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        ISqlBuilder Between<TEntity>( Expression<Func<TEntity, object>> expression, int? min, int? max, Boundary boundary = Boundary.Both ) where TEntity : class;
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        ISqlBuilder Between<TEntity>( Expression<Func<TEntity, object>> expression, double? min, double? max, Boundary boundary = Boundary.Both ) where TEntity : class;
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        ISqlBuilder Between<TEntity>( Expression<Func<TEntity, object>> expression, decimal? min, decimal? max, Boundary boundary = Boundary.Both ) where TEntity : class;
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        ISqlBuilder Between<TEntity>( Expression<Func<TEntity, object>> expression, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null ) where TEntity : class;
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        ISqlBuilder Between( string column, int? min, int? max, Boundary boundary = Boundary.Both );
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        ISqlBuilder Between( string column, double? min, double? max, Boundary boundary = Boundary.Both );
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        ISqlBuilder Between( string column, decimal? min, decimal? max, Boundary boundary = Boundary.Both );
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        ISqlBuilder Between( string column, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null );
        /// <summary>
        /// 是否分组
        /// </summary>
        bool IsGroup { get; }
        /// <summary>
        /// 分组列表
        /// </summary>
        string GroupColumns { get; }
        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="columns">分组字段,范例：a.Id,b.Name</param>
        /// <param name="having">分组条件,范例：Count(*) > 1</param>
        ISqlBuilder GroupBy( string columns, string having = null );
        /// <summary>
        /// 分组
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="columns">分组字段</param>
        ISqlBuilder GroupBy<TEntity>( params Expression<Func<TEntity, object>>[] columns );
        /// <summary>
        /// 分组
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">分组字段,范例：t => t.Name</param>
        /// <param name="having">分组条件,范例：Count(*) > 1</param>
        ISqlBuilder GroupBy<TEntity>( Expression<Func<TEntity, object>> column, string having = null );
        /// <summary>
        /// 添加到GroupBy子句
        /// </summary>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        ISqlBuilder AppendGroupBy( string sql );
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="order">排序列表,范例：a.Id,b.Name desc</param>
        /// <param name="tableAlias">表别名</param>
        ISqlBuilder OrderBy( string order, string tableAlias = null );
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">排序列,范例：t => t.Name</param>
        /// <param name="desc">是否倒排</param>
        ISqlBuilder OrderBy<TEntity>( Expression<Func<TEntity, object>> column, bool desc = false );
        /// <summary>
        /// 添加到Order By子句
        /// </summary>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        ISqlBuilder AppendOrderBy( string sql );
        /// <summary>
        /// 设置分页
        /// </summary>
        /// <param name="pager">分页参数</param>
        ISqlBuilder Page( IPager pager );
        /// <summary>
        /// 设置跳过行数
        /// </summary>
        /// <param name="count">跳过的行数</param>
        ISqlBuilder Skip( int count );
        /// <summary>
        /// 设置获取行数
        /// </summary>
        /// <param name="count">获取的行数</param>
        ISqlBuilder Take( int count );
        /// <summary>
        /// 分页
        /// </summary>
        IPager Pager { get; }
    }
}
