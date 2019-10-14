package br.com.alura.aluraviagens.ui.activity;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;

import java.math.BigDecimal;

import br.com.alura.aluraviagens.R;
import br.com.alura.aluraviagens.model.Pacote;
import br.com.alura.aluraviagens.util.DiasUtil;
import br.com.alura.aluraviagens.util.MoedaUtil;
import br.com.alura.aluraviagens.util.ResourceUtil;

public class ResumoPacoteActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_resumo_pacote);

        Pacote pacote = new Pacote("São Paulo", "sao_paulo_sp", 2, new BigDecimal(243.99));

        ((ImageView)findViewById(R.id.resumo_pacote_imagem)).setImageDrawable(ResourceUtil.devolveDrawable(this, pacote.getImagem()));
        ((TextView)findViewById(R.id.resumo_pacote_local)).setText(pacote.getLocal());
        ((TextView)findViewById(R.id.resumo_pacote_dias)).setText(DiasUtil.formataEmTexto(pacote.getDias()));
        ((TextView)findViewById(R.id.resumo_pacote_preco)).setText(MoedaUtil.formataMoeda(pacote.getPreco()));
    }
}
