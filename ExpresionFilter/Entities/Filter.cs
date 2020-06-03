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
    public class Filter
    {
        /// <summary>
        /// Une el filtro actual con un filtro anterior con una operacion logica
        /// </summary>
        public Enums.UnionFilter Union { get; set; }
        /// <summary>
        /// Define el tipo de dato
        /// </summary>
        public Enums.PropertyType PropertyType { get; set; }
        /// <summary>
        /// Nombre de la propiedad del repositorio
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Opcion de filtro
        /// </summary>
        public Enums.OptionFilter Operation { get; set; }
        /// <summary>
        /// Valor de de la propiedad a comparar
        /// </summary>
        public object Value { get; set; }
    }
}
