package br.com.alura.aluraviagens.ui.activity;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;

import java.math.BigDecimal;
import java.text.SimpleDateFormat;
import java.util.Calendar;

import br.com.alura.aluraviagens.R;
import br.com.alura.aluraviagens.model.Pacote;
import br.com.alura.aluraviagens.util.DiasUtil;
import br.com.alura.aluraviagens.util.MoedaUtil;
import br.com.alura.aluraviagens.util.ResourceUtil;

public class ResumoPacoteActivity extends AppCompatActivity {

    public static final String TITLE = "Resumo do pacote";
    public static final String PATTERN_DATA = "dd/MM";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_resumo_pacote);

        setTitle(TITLE);

        Pacote pacote = new Pacote("São Paulo", "sao_paulo_sp", 2, new BigDecimal(243.99));

        ((ImageView)findViewById(R.id.resumo_pacote_imagem)).setImageDrawable(ResourceUtil.devolveDrawable(this, pacote.getImagem()));
        ((TextView)findViewById(R.id.resumo_pacote_local)).setText(pacote.getLocal());
        ((TextView)findViewById(R.id.resumo_pacote_dias)).setText(DiasUtil.formataEmTexto(pacote.getDias()));
        ((TextView)findViewById(R.id.resumo_pacote_preco)).setText(MoedaUtil.formataMoeda(pacote.getPreco()));

        Calendar dataIda = Calendar.getInstance();
        Calendar dataVolta = Calendar.getInstance();
        dataVolta.add(Calendar.DATE, pacote.getDias());

        SimpleDateFormat dateFormatBr = new SimpleDateFormat(PATTERN_DATA);
        String dataFormatIda = dateFormatBr.format(dataIda.getTime());
        String dataFormatVolta = dateFormatBr.format(dataVolta.getTime());

        String dataFormatadaDaViagem = String.format("%s - %s de %d", dataFormatIda, dataFormatVolta, dataVolta.get(Calendar.YEAR));

        ((TextView)findViewById(R.id.resumo_pacote_data)).setText(dataFormatadaDaViagem);

    }
}
