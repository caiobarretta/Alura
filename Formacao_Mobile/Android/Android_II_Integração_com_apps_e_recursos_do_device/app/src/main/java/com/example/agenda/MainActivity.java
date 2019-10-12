package com.example.agenda;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.res.Configuration;
import android.net.Uri;
import android.os.Bundle;
import android.provider.Browser;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.agenda.adapter.AlunosAdapter;
import com.example.agenda.converter.AlunoConverter;
import com.example.agenda.dao.AlunoDAO;
import com.example.agenda.modelo.Aluno;

import java.util.List;

public class MainActivity extends AppCompatActivity {

    private ListView lstAlunos;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        lstAlunos = findViewById(R.id.lstAlunos);

        lstAlunos.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> lista, View item, int position, long id) {
                Aluno aluno = (Aluno) lstAlunos.getItemAtPosition(position);
                Intent intent = new Intent(MainActivity.this, FormularioActivity.class);
                intent.putExtra("aluno", aluno);
                startActivity(intent);
            }
        });
        Button novoAluno = findViewById(R.id.novo_aluno);
        novoAluno.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(MainActivity.this, FormularioActivity.class);
                startActivity(intent);
            }
        });

        registerForContextMenu(lstAlunos);
    }

    @Override
    protected void onResume() {
        super.onResume();
        carregaLista();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()){
            case R.id.menu_enviar_notas:
                new EnviaAlunoTask(this).execute();
                break;
        }
        return true;
    }

    private void carregaLista() {
        AlunoDAO dao = new AlunoDAO(this);
        List<Aluno> alunos = dao.buscaAlunos();
        dao.close();

        AlunosAdapter adapter = new AlunosAdapter(this, alunos);
        lstAlunos.setAdapter(adapter);
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, final ContextMenu.ContextMenuInfo menuInfo) {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) menuInfo;
        final Aluno aluno = (Aluno) lstAlunos.getItemAtPosition(info.position);

        MenuItem itemLigar = menu.add("Ligar");

        itemLigar.setOnMenuItemClickListener(new MenuItem.OnMenuItemClickListener() {
            @Override
            public boolean onMenuItemClick(MenuItem menuItem) {
                if (ActivityCompat.checkSelfPermission(MainActivity.this, Manifest.permission.CALL_PHONE)
                    != PackageManager.PERMISSION_GRANTED){

                    ActivityCompat.requestPermissions(MainActivity.this,
                            new String[] {Manifest.permission.CALL_PHONE},
                            123);
                }
                else{
                    Intent intentLigar = new Intent(Intent.ACTION_CALL);
                    intentLigar.setData(Uri.parse("tel:" + aluno.getTelefone()));
                    startActivity(intentLigar);
                }
                return false;
            }
        });

        MenuItem itemSMS = menu.add("Enviar SMS");
        Intent intentSMS = new Intent(Intent.ACTION_VIEW);
        intentSMS.setData(Uri.parse("sms:" + aluno.getTelefone()));
        itemSMS.setIntent(intentSMS);

        MenuItem itemMapa = menu.add("Visualizar no mapa");
        Intent intentMapa = new Intent(Intent.ACTION_VIEW);
        intentMapa.setData(Uri.parse("geo:0,0?q=" + aluno.getEndereco()));
        itemMapa.setIntent(intentMapa);

        MenuItem itemSite = menu.add("Visitar Site");
        Intent intentSite = new Intent(Intent.ACTION_VIEW);
        String site = aluno.getSite();
        if(!site.startsWith("http://")){
            site = "http://" + site;
        }

        intentSite.setData(Uri.parse(site));
        itemSite.setIntent(intentSite);

        MenuItem deletar = menu.add("Deletar");
        deletar.setOnMenuItemClickListener(new MenuItem.OnMenuItemClickListener() {
            @Override
            public boolean onMenuItemClick(MenuItem menuItem) {
                AlunoDAO dao = new AlunoDAO(MainActivity.this);
                dao.deleta(aluno);
                dao.close();

                carregaLista();
                return false;
            }
        });
    }

    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);
        if (newConfig.orientation == Configuration.ORIENTATION_LANDSCAPE) {
            Toast.makeText(this, "ORIENTATION_LANDSCAPE", Toast.LENGTH_LONG).show();
            createHorizontalalLayout();
        } else if (newConfig.orientation == Configuration.ORIENTATION_PORTRAIT){
            Toast.makeText(this, "ORIENTATION_PORTRAIT", Toast.LENGTH_LONG).show();
            createVerticalLayout();
        }
    }

    private void createVerticalLayout() {
        setContentView(R.layout.activity_main);
    }

    private void createHorizontalalLayout() {
        setContentView(R.layout.activity_main);
    }
}
