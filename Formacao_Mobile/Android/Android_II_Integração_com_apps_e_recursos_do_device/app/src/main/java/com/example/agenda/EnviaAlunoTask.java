package com.example.agenda;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.widget.Toast;

import com.example.agenda.converter.AlunoConverter;
import com.example.agenda.dao.AlunoDAO;
import com.example.agenda.modelo.Aluno;

import java.util.List;

public class EnviaAlunoTask extends AsyncTask<Void, Void, String> {


    private Context context;
    private ProgressDialog dialog;

    public EnviaAlunoTask(Context context){
        this.context = context;
    }

    @Override
    protected String doInBackground(Void... objects) {
        AlunoDAO dao = new AlunoDAO(context);
        List<Aluno> alunos = dao.buscaAlunos();

        AlunoConverter conversor = new AlunoConverter();
        String json = conversor.converteParaJSON(alunos);

        WebClient client = new WebClient();
        String resposta = client.post(json);

        return resposta;
    }

    @Override
    protected void onPreExecute() {
        dialog = ProgressDialog.show(context, "Aguarde!", "Enviando alunos...", true, true);
    }

    @Override
    protected void onPostExecute(String resposta) {
        Toast.makeText(context, resposta, Toast.LENGTH_SHORT).show();
        dialog.dismiss();
    }
}
