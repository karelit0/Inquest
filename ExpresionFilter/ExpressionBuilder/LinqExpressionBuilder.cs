/// <copyright file="LinqExpressionBuilder.cs" company="Kinare">
/// Copyright (c) 2012 All Rights Reserved
/// </copyright>
/// <author>Daniel Marcelo Maldonado Sanchez</author>
/// <date>01/07/2014</date>
/// <summary>Evaluacion de expresiones</summary>
namespace KinareApp.NetFramework.ExpressionBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using KinareApp.NetFramework.Entities;
    using System.Web.UI.WebControls;
    using ExpresionFilter.ExpressionBuilder;


    /// <summary>
    /// Construccion de una expresion generica
    /// </summary>
    public class LinqExpressionBuilder : ILinqExpressionBuilder
    {
        #region Variables privadas
        /// <summary>
        /// Evaluacion de funcion 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>True</returns>
        private Expression<Func<T, bool>> True<T>() { return f => true; }
        /// <summary>
        /// Evaluacion de funcion 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>False</returns>
        private Expression<Func<T, bool>> False<T>() { return f => false; }
        /// <summary>
        /// Referencia al metodo "Contiene"
        /// </summary>
        private MethodInfo objContainsMethod = typeof(string).GetMethod("Contains");
        /// <summary>
        /// Referencia al metodo "Inicia con"
        /// </summary>
        private MethodInfo objStartsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        /// <summary>
        /// Referencia al metodo "Termina en"
        /// </summary>
        private MethodInfo objEndsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor
        /// </summary>
        public LinqExpressionBuilder()
        {
        }
        #endregion

        #region Funciones publicas
        /// <summary>
        /// Crea una expresion
        /// </summary>
        /// <typeparam name="T">Tipo de dato del repositorio "Model.Template"</typeparam>
        /// <returns>Expression de clausula Where</returns>
        public Expression<System.Func<T, bool>> GetFilterExpression<T>(IList<Filter> objFilterList)
        {
            try
            {
                if (objFilterList == null)
                    return null;

                if (objFilterList.Count < 1)
                    return null;

                ParameterExpression objParameterExpression = Expression.Parameter(typeof(T), "Model.Template");
                Expression objExpression = null;

                while (objFilterList.Count > 0)
                {
                    objFilterList[0] = this.CheckFilter(objFilterList[0]);

                    if (objExpression == null)
                        objExpression = GetExpression<T>(objParameterExpression, objFilterList[0]);
                    else
                        objExpression = Enums.UnionFilter.And == objFilterList[0].Union ?
                                        Expression.AndAlso(objExpression, GetExpression<T>(objParameterExpression, objFilterList[0])) :
                                        Expression.OrElse(objExpression, GetExpression<T>(objParameterExpression, objFilterList[0]));

                    objFilterList.Remove(objFilterList[0]);
                }

                return Expression.Lambda<Func<T, bool>>(objExpression, objParameterExpression);
            }
            catch (Exception objException)
            {
                throw objException;
            }

        }
        /// <summary>
        /// Crea una exprecion para ordenar
        /// </summary>
        /// <typeparam name="T">Tipo de dato del repositorio "Model.Template"</typeparam>
        /// <param name="objSorterList">Lista de ordenamientos a aplicar</param>
        /// <returns>Expression de clausula Where</returns>
        public IEnumerable<T> OrderByColumnName<T>(IEnumerable<T> collection, string columnName, bool ascendig)
        {
            try
            {
                if (collection == null)
                    return collection;

                if (collection.Count() < 2)
                    return collection;

                if (string.IsNullOrWhiteSpace(columnName))
                    return collection;

                Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> expression = new SortExpressionConverter<T>().Convert(ascendig);
                Func<T, object> lambda = SortLambdaBuilder<T>.Build(columnName);
                collection = expression(collection, lambda);
                return collection;
            }
            catch (Exception)
            {
                return collection;
            }

        }
        /// <summary>
        /// Aplica el ordenamiento sobre una lista
        /// </summary>
        /// <typeparam name="T">Tipo de Base de la lista</typeparam>
        /// <param name="collection">Lista</param>
        /// <param name="columnName">Nombre de columna</param>
        /// <param name="ascendig">Orden ascendente</param>
        /// <returns>Lista despues de aplicar los filtros</returns>
        public IEnumerable<T> OrderBySorter<T>(IEnumerable<T> collection, Sorter sorter)
        {
            try
            {
                if (collection == null)
                    return collection;

                if (collection.Count() < 2)
                    return collection;

                if (sorter == null)
                    return collection;

                if (string.IsNullOrWhiteSpace(sorter.PropertyName))
                    return collection;

                Func<IEnumerable<T>, Func<T, object>, IEnumerable<T>> expression = new SortExpressionConverter<T>().Convert(sorter.SortDirection);

                Func<T, object> lambda = SortLambdaBuilder<T>.Build(sorter.PropertyName);

                collection = expression(collection, lambda);

                return collection;
            }
            catch (Exception)
            {
                return collection;
            }
        }
        #endregion
        #region Funciones privadas
        /// <summary>
        /// Set the type of object value to correspondig type
        /// </summary>
        /// <param name="objFilter">Filter</param>
        /// <returns>Filter</returns>
        private Filter CheckFilter(Filter objFilter)
        {
            try
            {
                switch (objFilter.PropertyType)
                {
                    case Enums.PropertyType.Guid:
                        {
                            var newGuid = new Guid();
                            Guid.TryParse(objFilter.Value.ToString(), out newGuid);
                            objFilter.Value = newGuid;
                            break;
                        }
                    case Enums.PropertyType.Text: { objFilter.Value = objFilter.Value.ToString(); break; }
                    case Enums.PropertyType.Int: { objFilter.Value = Convert.ToInt32(objFilter.Value); break; }
                    case Enums.PropertyType.Decimal: { objFilter.Value = Convert.ToDecimal(objFilter.Value); break; }
                    case Enums.PropertyType.DateTime: { objFilter.Value = Convert.ToDateTime(objFilter.Value); break; }
                    case Enums.PropertyType.Bool: { objFilter.Value = Convert.ToBoolean(objFilter.Value); break; }
                    default: { objFilter.Value = null; break; }
                }
                return objFilter;
            }
            catch (Exception objException)
            {
                throw objException;
            }
        }
        /// <summary>
        /// Evalua un filtro y crea una expresion del filtro
        /// </summary>
        /// <typeparam name="T">Tipo de dato del repositorio "Model.Template"</typeparam>
        /// <param name="objParameterExpression">Parametro del tipo de dato del repositorio</param>
        /// <param name="objFilter">Filtro a evaluar</param>
        /// <returns></returns>
        private Expression GetExpression<T>(ParameterExpression objParameterExpression, Filter objFilter)
        {
            try
            {
                MemberExpression objMemberExpression = Expression.Property(objParameterExpression, objFilter.PropertyName);
                ConstantExpression objConstantExpression = Expression.Constant(objFilter.Value);

                switch (objFilter.Operation)
                {
                    case Enums.OptionFilter.Contains:
                        return Expression.Call(objMemberExpression, objContainsMethod, objConstantExpression);

                    case Enums.OptionFilter.EndsWith:
                        return Expression.Call(objMemberExpression, objEndsWithMethod, objConstantExpression);

                    case Enums.OptionFilter.Equals:
                        return Expression.Equal(objMemberExpression, objConstantExpression);

                    case Enums.OptionFilter.GreaterThan:
                        return Expression.GreaterThan(objMemberExpression, objConstantExpression);

                    case Enums.OptionFilter.GreaterThanOrEqual:
                        return Expression.GreaterThanOrEqual(objMemberExpression, objConstantExpression);

                    case Enums.OptionFilter.LessThan:
                        return Expression.LessThan(objMemberExpression, objConstantExpression);

                    case Enums.OptionFilter.LessThanOrEqual:
                        return Expression.LessThanOrEqual(objMemberExpression, objConstantExpression);

                    case Enums.OptionFilter.NotEqual:
                        return Expression.NotEqual(objMemberExpression, objConstantExpression);

                    case Enums.OptionFilter.StartsWith:
                        return Expression.Call(objMemberExpression, objStartsWithMethod, objConstantExpression);
                }

                return null;
            }
            catch (Exception objException)
            {
                throw objException;
            }

        }
        #endregion
    }
}

