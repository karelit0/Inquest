using System.Collections.Generic;
/// <copyright file="ILinqExpressionBuilder.cs" company="Kinare">
/// Copyright (c) 2012 All Rights Reserved
/// </copyright>
/// <author>Daniel Marcelo Maldonado Sanchez</author>
/// <date>01/07/2014</date>
/// <summary>Evaluacion de expresiones</summary>
namespace KinareApp.NetFramework.ExpressionBuilder
{

    /// <summary>
    /// Construccion de una expresion generica
    /// </summary>
    public interface ILinqExpressionBuilder
    {
        /// <summary>
        /// Crea una exprecion para filtrar
        /// </summary>
        /// <typeparam name="T">Tipo de dato del repositorio "Model.Template"</typeparam>
        /// <param name="objFilterList">Lista de filtros a aplicar</param>
        /// <returns>Expression de clausula Where</returns>
        System.Linq.Expressions.Expression<System.Func<T, bool>> GetFilterExpression<T>(System.Collections.Generic.IList<Entities.Filter> objFilterList);
        /// <summary>
        /// Aplica el ordenamiento sobre una lista
        /// </summary>
        /// <typeparam name="T">Tipo de Base de la lista</typeparam>
        /// <param name="collection">Lista</param>
        /// <param name="columnName">Nombre de columna</param>
        /// <param name="ascendig">Orden ascendente</param>
        /// <returns>Lista despues de aplicar los filtros</returns>
        IEnumerable<T> OrderByColumnName<T>(IEnumerable<T> collection, string columnName, bool ascendig);
        /// <summary>
        /// Aplica el ordenamiento sobre una lista
        /// </summary>
        /// <typeparam name="T">Tipo de Base de la lista</typeparam>
        /// <param name="collection">Lista</param>
        /// <param name="sorterList">Lista de ordamientos a aplicar</param>
        /// <returns>Lista despues de aplicar los filtros</returns>
        IEnumerable<T> OrderBySorter<T>(IEnumerable<T> collection, Entities.Sorter sorter);
    }
}

