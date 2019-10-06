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
        super(context, "Agenda", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        String sql = "CREATE TABLE Alunos ( id INTERGER PRIMARY KEY, nome TEXT NOT NULL, endereco TEXT, telefone TEXT, site TEXT, nota REAL);";
        sqLiteDatabase.execSQL(sql);
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        String sql = "DROP TABLE IF EXISTS Alunos";
        sqLiteDatabase.execSQL(sql);
        onCreate(sqLiteDatabase);
    }

    public void insere(Aluno aluno) {
        SQLiteDatabase sqLiteDatabase = getWritableDatabase();

        ContentValues dados = new ContentValues();
        dados.put("nome", aluno.getNome());
        dados.put("endereco", aluno.getEndereco());
        dados.put("telefone", aluno.getTelefone());
        dados.put("site", aluno.getSite());
        dados.put("nota", aluno.getNota());

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
            Alunos.add(Aluno);
        }
        c.close();

        return Alunos;
    }
}
