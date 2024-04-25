﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
         
        [Required(ErrorMessage ="El numero de serie es requerido")]
        [MaxLength(30,ErrorMessage ="Maximo 30 caracteres")]
        public string NumeroSerie{ get; set; }

        [Required(ErrorMessage = "La Descripcion es requerida")]
        [MaxLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Descripcion {  get; set; }

        [Required(ErrorMessage ="Se necesita el precio del producto")]
        public double Precio { get; set; }


        [Required(ErrorMessage = "Se necesita el costo del producto")]

        public double Costo { get; set; }

        public string ImagenUrl {  get; set; }

        [Required(ErrorMessage ="El estado es requerido")]
        public bool Estado { get; set; }

        //Hagamos la relacion con la tabla Categoria

        [Required(ErrorMessage ="La churros es Requerida")]
        public int ChurrosId { get; set; }

        [ForeignKey("ChurrosId")]
        public Churros Churros { get; set; }

        //Hagamos la relacion con la tabla Marca

        [Required(ErrorMessage = "La papa es Requerida")]
        public int PapasId { get; set; }

        [ForeignKey("PapasId")]
        public Papas Papas { get; set; }

        //Hagamos la Recursividad del Padre
        
        public int? PadreId { get; set; }

        public virtual Producto Padre { get; set; }
    }
}
