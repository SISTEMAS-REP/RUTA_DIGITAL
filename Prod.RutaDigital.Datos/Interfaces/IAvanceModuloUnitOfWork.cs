﻿using Release.Helper.Data.ICore;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    Task<IEnumerable<AvanceModuloResponse>>
        ListarAvancesModulos(AvanceModuloRequest request);

    Task<int>
        InsertarAvanceModulo(AvanceModuloRequest request);
}