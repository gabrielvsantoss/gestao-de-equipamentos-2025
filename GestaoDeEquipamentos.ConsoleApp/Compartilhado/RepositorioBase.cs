using System.Collections;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public abstract class RepositorioBase
{
    private ArrayList registros = new ArrayList();
    private int contadorIds = 0;

    public void CadastrarRegistro(EntidadeBase novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        registros.Add(novoRegistro);
    }

    public bool EditarRegistro(int idRegistro, EntidadeBase registroEditado)
    {
        foreach (EntidadeBase item in registros)
        {
            if (item.Id == idRegistro)
            {
                item.AtualizarRegistro(registroEditado);

                return true;
            }
        }

        return false;
    }

    public bool ExcluirRegistro(int idRegistro)
    {
        #region iteração com for
        //for (int i = 0; i < registros.Count; i++)
        //{
        //    EntidadeBase registroSelecionado = (EntidadeBase)registros[i];

        //    if (registroSelecionado == null)
        //        continue;

        //    else if (registroSelecionado.Id == idRegistro)
        //    {
        //        registros.Remove(registroSelecionado);

        //        return true;
        //    }
        //}
        #endregion

        EntidadeBase registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado != null)
        {
            registros.Remove(registroSelecionado);

            return true;
        }

        return false;
    }

    public ArrayList SelecionarRegistros()
    {
        return registros;
    }

    public EntidadeBase SelecionarRegistroPorId(int idRegistro)
    {
        foreach (EntidadeBase item in registros)
        {
            if (item.Id == idRegistro)
                return item;
        }
      
        return null;
    }
}
