package br.com.alura.aluraviagens.ui.activity;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;

import java.math.BigDecimal;

import br.com.alura.aluraviagens.R;
import br.com.alura.aluraviagens.model.Pacote;
import br.com.alura.aluraviagens.util.DataUtil;
import br.com.alura.aluraviagens.util.DiasUtil;
import br.com.alura.aluraviagens.util.MoedaUtil;
import br.com.alura.aluraviagens.util.ResourceUtil;

public class ResumoPacoteActivity extends AppCompatActivity {

    public static final String TITLE = "Resumo do pacote";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_resumo_pacote);

        setTitle(TITLE);

        Pacote pacote = new Pacote("São Paulo", "sao_paulo_sp", 2, new BigDecimal(243.99));
        mostrarImagem(pacote);
        mostrarLocal(pacote);
        mostrarDias(pacote);
        mostrarPreco(pacote);
        mostraData(pacote);

    }

    private void mostraData(Pacote pacote) {
        ((TextView)findViewById(R.id.resumo_pacote_data)).setText(DataUtil.periodoEmTexto(pacote.getDias()));
    }

    private void mostrarPreco(Pacote pacote) {
        ((TextView)findViewById(R.id.resumo_pacote_preco)).setText(MoedaUtil.formataMoeda(pacote.getPreco()));
    }

    private void mostrarDias(Pacote pacote) {
        ((TextView)findViewById(R.id.resumo_pacote_dias)).setText(DiasUtil.formataEmTexto(pacote.getDias()));
    }

    private void mostrarLocal(Pacote pacote) {
        ((TextView)findViewById(R.id.resumo_pacote_local)).setText(pacote.getLocal());
    }

    private void mostrarImagem(Pacote pacote) {
        ((ImageView)findViewById(R.id.resumo_pacote_imagem)).setImageDrawable(ResourceUtil.devolveDrawable(this, pacote.getImagem()));
    }
}
