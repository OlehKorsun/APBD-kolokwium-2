using Kolokwium2.Data;
using Kolokwium2.DTOs;
using Kolokwium2.Exceptions;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using DataException = System.Data.DataException;

namespace Kolokwium2.Services;

public class MachineService: IMachineService
{
    
    private readonly ApbdContext _context;

    public MachineService(ApbdContext context)
    {
        _context = context;
    }
    
    public async Task PostMachineAsync(PostMachineRequest request)
    {
        if (request.WashingMachine.MaxWeight < 8)
        {
            throw new DataException("Maksymalna dopuszczalna waga nie może być mniejsza niż 8!");
        }

        if (request.AvailablePrograms.Any(p => p.Price > 25))
        {
            throw new Exceptions.DataException("Cena za program nie może przekraczać 25!");
        }

        if (_context.WashingMachines.Any(m => m.SerialNumber == request.WashingMachine.SerialNumber))
        {
            throw new MachineAlreadyExistsException($"Już istnieje pralka o numerze seryjnym: {request.WashingMachine.SerialNumber}");
        }

        var programs = new List<ProgramEntity>();
        
        foreach (var program in request.AvailablePrograms)
        {
            var contextProgram = await _context.Programs.FirstOrDefaultAsync(a => a.Name == program.ProgramName);
            if (contextProgram == null)
            {
                throw new ProgramNotFoundException($"Nie znaleziono programu o nazwie: {program.ProgramName}");
            }
            programs.Add(contextProgram);
        }

        var washingMachine = new Washing_Machine()
        {
            SerialNumber = request.WashingMachine.SerialNumber,
            MaxWeight = request.WashingMachine.MaxWeight,
            AvailablePrograms = new List<Available_Program>()
        };

        _context.WashingMachines.Add(washingMachine);

        foreach (var program in programs)
        {
            washingMachine.AvailablePrograms.Add(new Available_Program()
            {
                Price = 
            });
        }

    }
}