package com.example.agenda;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.example.agenda.modelo.Prova;

import java.util.Arrays;
import java.util.List;

public class ListaProvaFragment extends Fragment {

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_lista_provas, container, false);
        Prova provaPortugues = new Prova("Português", "25/05/2016", Arrays.asList("Sujeito", "Objeto Direto", "Objeto Indireto"));
        Prova provaMatematica = new Prova("Matemática", "27/05/2016", Arrays.asList("Conjuntos", "Equação 1° Grau", "Equação 2° Grau"));
        List<Prova> provas = Arrays.asList(provaPortugues, provaMatematica);

        ArrayAdapter<Prova> adapter = new ArrayAdapter<Prova>(getContext(), android.R.layout.simple_list_item_1, provas);
        ListView lista = view.findViewById(R.id.provas_lista);
        lista.setAdapter(adapter);

        lista.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Prova prova = (Prova) parent.getItemAtPosition(position);
                Toast.makeText(getContext(), "Clicou na prova de: " + prova.getMateria(), Toast.LENGTH_LONG).show();

                Intent intent = new Intent(getContext(), DetalhesProvaActivity.class);
                intent.putExtra("prova", prova);
                startActivity(intent);
            }
        });
        return view;
    }
}
