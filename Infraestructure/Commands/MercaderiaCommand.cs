﻿using Application.Interfaces.ICommands;
using Application.Request;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Commands
{
    public class MercaderiaCommand : IMercaderiaCommand
    {
        private readonly AppDbContext _context;
        public MercaderiaCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Mercaderia> Insert(Mercaderia mercaderia)
        {

            await _context.Mercaderia.AddAsync(mercaderia);

            await _context.SaveChangesAsync();
            return mercaderia;

        }
        public async Task<Mercaderia> Update(int mercaderiaId, MercaderiaRequest request)
        {
            var updateMercaderia = _context.Mercaderia
                .FirstOrDefault(x => x.MercaderiaId == mercaderiaId);
            
            updateMercaderia.Nombre = request.nombre;
            updateMercaderia.TipoMercaderiaId = request.tipo;
            updateMercaderia.Precio = request.precio;
            updateMercaderia.Ingredientes = request.ingredientes;
            updateMercaderia.Preparacion = request.preparacion;
            updateMercaderia.Imagen = request.imagen;

            _context.Update(updateMercaderia);
            await _context.SaveChangesAsync();

            return updateMercaderia;
    }

        public async Task<Mercaderia> Delete(int id)
        {
            Mercaderia mercaderia = await _context.Mercaderia
                .Include(m => m.TipoMercaderia)
                .FirstOrDefaultAsync(m => m.MercaderiaId == id);

            if (mercaderia == null)
            {
                return null;
            }

            _context.Mercaderia.Remove(mercaderia);
            await _context.SaveChangesAsync();
            return mercaderia;
        }

    }
}