using RallyVinicius.Dominio.DbContexto;
using RallyVinicius.Dominio.Entidades;
using RallyVinicius.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RallyVinicius.Dominio.Repositorio
{
    public class PilotoRepositorio : IPilotoRepositorio
    {
        private readonly RallyDbContexto _rallyDbContexto;

        public PilotoRepositorio(RallyDbContexto rallyDbContexto)
        {
            _rallyDbContexto = rallyDbContexto;
        }

        public void Adicionar(Piloto piloto)
        {
            _rallyDbContexto.Pilotos.Add(piloto);
            _rallyDbContexto.SaveChanges();
        }

        public void Atualizar(Piloto piloto)
        {
            //PUT e PATCH utilizam método, sendo assim é preciso diferenciar quando o objeto já esta 'tracked'. No caso de 'patch' já estará.
            //No caso de PUT será uma nova instância proveniente de um 'map' do modelo e então 'anexa' ao monitoramento do entity framework.
            //O entity framework não permite que um objeto 'tracked' seja duplicado, por isso da verificação.
            if(_rallyDbContexto.Entry(piloto).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                //Inclui o objeto no monitoramento do entity framework.
                _rallyDbContexto.Attach(piloto); 
                //Deve definir 'forçado' o estado para 'modified' porque se não o entity framework tentará 'inserir' o objeto. Como
                //já sabemos que o método esta em um contexto de 'atualização', esta operação torna-se segura e necessária.
                _rallyDbContexto.Entry(piloto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                //Aqui entrará em caso de 'patch' já que o objeto já é um objeto 'tracked' pelo entity framework. Inclusive em caso
                //de efetiva alteração de alguma propriedade, o 'state' estará como 'modified'. Caso contrário estará como
                //'unchanged'.
                _rallyDbContexto.Update(piloto);
            }

            //Efetiva as alterações no banco.
            _rallyDbContexto.SaveChanges();
        }

        public ICollection<Piloto> ObterTodos()
        {
            return _rallyDbContexto.Pilotos.ToList();
        }

        public ICollection<Piloto> ObterTodosPilotos(string nome)
        {
            return _rallyDbContexto.Pilotos.Where(x => x.Nome.Contains(nome))
                                           .ToList();
        }

        public bool Existe(int pilotoId)
        {
            return _rallyDbContexto.Pilotos.Any(x => x.Id == pilotoId);
        }

        public Piloto Obter(int pilotoId)
        {
            return _rallyDbContexto.Pilotos.FirstOrDefault(x => x.Id == pilotoId);
        }

        public void Remover(Piloto piloto)
        {
            _rallyDbContexto.Pilotos.Remove(piloto);
            _rallyDbContexto.SaveChanges();
        }
    }
}
