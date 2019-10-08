package com.example.agenda.dao;

import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

import com.example.agenda.modelo.Aluno;

import java.util.ArrayList;
import java.util.List;

public class AlunoDAO extends SQLiteOpenHelper {

    public AlunoDAO(@Nullable Context context) {
        super(context, "Agenda", null, 2);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        String sql = "CREATE TABLE Alunos ( " +
                "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "nome TEXT NOT NULL, " +
                "endereco TEXT, " +
                "telefone TEXT, " +
                "site TEXT, " +
                "nota REAL, " +
                "caminhoFoto TEXT);";
        sqLiteDatabase.execSQL(sql);
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int oldVersion, int newVersion) {
        String sql = "";
        switch (oldVersion){

            case 1:
                sql = "AlTER TABLE Alunos ADD COLUMN caminhoFoto TEXT";
                sqLiteDatabase.execSQL(sql);
        }
        //onCreate(sqLiteDatabase);
    }

    public void insere(Aluno aluno) {
        SQLiteDatabase sqLiteDatabase = getWritableDatabase();
        ContentValues dados = pegaDadosDoAluno(aluno);
        sqLiteDatabase.insert("Alunos", null, dados);
    }

    public List<Aluno> buscaAlunos() {
        String sql = "SELECT * FROM Alunos;";
        SQLiteDatabase sqLiteDatabase = getReadableDatabase();

        Cursor c = sqLiteDatabase.rawQuery(sql, null);

        List<Aluno> Alunos = new ArrayList<Aluno>();
        while(c.moveToNext()){
            Aluno Aluno = new Aluno();
            Aluno.setId(c.getLong(c.getColumnIndex("id")));
            Aluno.setNome(c.getString(c.getColumnIndex("nome")));
            Aluno.setEndereco(c.getString(c.getColumnIndex("endereco")));
            Aluno.setTelefone(c.getString(c.getColumnIndex("telefone")));
            Aluno.setSite(c.getString(c.getColumnIndex("site")));
            Aluno.setNota(c.getDouble(c.getColumnIndex("nota")));
            Aluno.setCaminhoFoto(c.getString(c.getColumnIndex("caminhoFoto")));
            Alunos.add(Aluno);
        }
        c.close();

        return Alunos;
    }

    public void deleta(Aluno aluno) {
        SQLiteDatabase sqLiteDatabase = getWritableDatabase();
        String[] params = {aluno.getId().toString()};
        sqLiteDatabase.delete("Alunos", "id = ?", params);
    }

    public void altera(Aluno aluno) {
        SQLiteDatabase sqLiteDatabase = getWritableDatabase();
        ContentValues dados = pegaDadosDoAluno(aluno);
        String[] params = {aluno.getId().toString()};
        sqLiteDatabase.update("Alunos", dados, "id = ?", params);
    }

    private ContentValues pegaDadosDoAluno(Aluno aluno) {
        ContentValues dados = new ContentValues();
        dados.put("nome", aluno.getNome());
        dados.put("endereco", aluno.getEndereco());
        dados.put("telefone", aluno.getTelefone());
        dados.put("site", aluno.getSite());
        dados.put("nota", aluno.getNota());
        dados.put("caminhoFoto", aluno.getCaminhoFoto());
        return dados;
    }
}
