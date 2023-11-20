using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CursosDigitalApp.Models;
using SQLite;

namespace CursosDigitalApp.Data
{
   public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);

            db = new SQLiteAsyncConnection(dbPath);

            db = new SQLiteAsyncConnection(dbPath);

            db = new SQLiteAsyncConnection(dbPath);

            db.CreateTableAsync<Empleado>().Wait();

            db.CreateTableAsync<Curso>().Wait();

            db.CreateTableAsync<Administradores>().Wait();

            db.CreateTableAsync<SeguimientoEmpleado>().Wait();

        }

        public Task<int> SaveEmpleadoAsyc(Empleado emple)
        {
            if (emple.Noemp != 0)
            {
                return db.UpdateAsync(emple);
            }
            else
            {
                return db.InsertAsync(emple);
            }
        }

        public Task<int> SaveCursoAsyc(Curso curs)
        {
            if (curs.IdCurso != 0)
            {
                return db.UpdateAsync(curs);
            }
            else
            {
                return db.InsertAsync(curs);
            }
        }

        public Task<int> SaveAdminAsyc(Administradores admin)
        {
            if (admin.AdminId != 0)
            {
                return db.UpdateAsync(admin);
            }
            else
            {
                return db.InsertAsync(admin);
            }
        }

        public Task<int> SaveSeguimientoAsyc(SeguimientoEmpleado Segui)
        {
            if (Segui.IdSeg != 0)
            {
                return db.UpdateAsync(Segui);
            }
            else
            {
                return db.InsertAsync(Segui);
            }
        }

        public Task<Empleado> GetEmpleadoByIdAsync(int Noemp)
        {

            return db.Table<Empleado>().Where(a => a.Noemp == Noemp).FirstOrDefaultAsync();

        }

        public Task<Curso> GetCursoByIdAsync(int IdCurso)
        {

            return db.Table<Curso>().Where(a => a.IdCurso == IdCurso).FirstOrDefaultAsync();

        }

        public Task<SeguimientoEmpleado> GetSeguimientoByIdAsync(int IdSeg)
        {

            return db.Table<SeguimientoEmpleado>().Where(a => a.IdSeg == IdSeg).FirstOrDefaultAsync();

        }




        public Task<List<Empleado>> GetEmpleadoAsync()
        {
            return db.Table<Empleado>().ToListAsync();
        }

        public Task<List<Curso>> GetCursoAsync()
        {
            return db.Table<Curso>().ToListAsync();
        }

        public Task<List<SeguimientoEmpleado>> GetSeguimientoAsync()
        {
            return db.Table<SeguimientoEmpleado>().ToListAsync();
        }

        public Task<List<Administradores>> GetAdminValidate(string email, string password)
        {
            return db.QueryAsync<Administradores>("SELECT * FROM Administradores WHERE Email='" + email + "' AND Pass='" + password + "'");

        }

        public Task<int> DeleteEmpleadoAsync(Empleado empleado)
        {
            return db.DeleteAsync(empleado);
        }
        public Task<int> DeleteCursoAsync(Curso curso)
        {
            return db.DeleteAsync(curso);
        }

        public Task<int> DeleteSeguimientoAsync(SeguimientoEmpleado segui)
        {
            return db.DeleteAsync(segui);
        }
    }
}
