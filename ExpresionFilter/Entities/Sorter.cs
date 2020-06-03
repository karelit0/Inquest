/// <copyright file="Filter.cs" company="Kinare">
/// Copyright (c) 2012 All Rights Reserved
/// </copyright>
/// <author>Daniel Marcelo Maldonado Sanchez</author>
/// <date>01/07/2014</date>
/// <summary>Evaluacion de expresiones</summary>
namespace KinareApp.NetFramework.Entities
{
    /// <summary>
    /// Filtro a usar en repositorios
    /// </summary>
    public class Sorter
    {
        /// <summary>
        /// Nombre de la propiedad del repositorio
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Direccion de ordenamiento
        /// </summary>
        public bool SortDirection { get; set; }
    }
}
