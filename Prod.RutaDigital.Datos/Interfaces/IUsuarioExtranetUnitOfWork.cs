﻿using Prod.RutaDigital.Entidades;
using Release.Helper.Data.ICore;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    Task<UsuarioExtranetResponse>
        BuscarUsuario(UsuarioExtranetRequest request);
}