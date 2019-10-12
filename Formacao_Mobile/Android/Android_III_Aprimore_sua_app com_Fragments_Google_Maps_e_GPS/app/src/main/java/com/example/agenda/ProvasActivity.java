package com.example.agenda;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.example.agenda.modelo.Prova;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.List;

public class ProvasActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_provas);

        Prova provaPortugues = new Prova("Português", "25/05/2016", Arrays.asList("Sujeito", "Objeto Direto", "Objeto Indireto"));
        Prova provaMatematica = new Prova("Matemática", "27/05/2016", Arrays.asList("Conjuntos", "Equação 1° Grau", "Equação 2° Grau"));
        List<Prova> provas = Arrays.asList(provaPortugues, provaMatematica);

        ArrayAdapter<Prova> adapter = new ArrayAdapter<Prova>(this, android.R.layout.simple_list_item_1, provas);
        ListView lista = findViewById(R.id.provas_lista);
        lista.setAdapter(adapter);

        lista.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Prova prova = (Prova) parent.getItemAtPosition(position);
                Toast.makeText(ProvasActivity.this, "Clicou na prova de: " + prova.getMateria(), Toast.LENGTH_LONG).show();

                Intent intent = new Intent(ProvasActivity.this, DetalhesProvaActivity.class);
                intent.putExtra("prova", prova);
                startActivity(intent);
            }
        });
    }
}
