using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej5.Domain;

public class VehiculoCombustible: Vehiculo
{
    private double kilometrosPorLitro;
    private double litrosExtra;

    public VehiculoCombustible(string patente, string marca, string modelo, int anio, double capacidadCarga, 
        Sucursal sucursal, double kilometrosPorLitro, double litrosExtra) : base(VehiculoTipo.Combustible, patente, marca, modelo, anio, capacidadCarga, sucursal)
    {
        this.kilometrosPorLitro = kilometrosPorLitro;
        this.litrosExtra = litrosExtra;
    }

    public double GetKilometrosPorLitro()
    {
        return kilometrosPorLitro;
    }

    public double GetLitrosExtra()
    {
        return litrosExtra;
    }

    public override double CalcularConsumo(double kilometros)
    {
        double consumo;
        int antiguedad = DateTime.Now.Year - GetAnio(); //con esto puedo hacer que se actualize el año pero seria mas especifico si en anio estuvieran los meses y dias 

        if (antiguedad >= 5)
        {
            consumo = (kilometros / kilometrosPorLitro) + (kilometros / 15) * litrosExtra; //se suman los litros extra cada 15km 
        }
        else
        {
            consumo = (kilometros / kilometrosPorLitro);
        }
        return consumo;
    }
}
