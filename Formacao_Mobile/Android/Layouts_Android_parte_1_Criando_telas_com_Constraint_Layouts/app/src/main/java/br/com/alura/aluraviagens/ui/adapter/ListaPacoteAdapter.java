package br.com.alura.aluraviagens.ui.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.List;
import java.util.Locale;

import br.com.alura.aluraviagens.R;
import br.com.alura.aluraviagens.model.Pacote;

public class ListaPacoteAdapter extends BaseAdapter {

    private final List<Pacote> pacotes;
    private final Context context;

    public ListaPacoteAdapter(List<Pacote> pacotes, Context context){
        this.pacotes = pacotes;
        this.context = context;
    }

    @Override
    public int getCount() {
        return pacotes.size();
    }

    @Override
    public Object getItem(int posicao) {
        return pacotes.get(posicao);
    }

    @Override
    public long getItemId(int id) {
        return 0;
    }

    @Override
    public View getView(int posicao, View view, ViewGroup parent) {
        View viewInflate = LayoutInflater.from(context).inflate(R.layout.item_pacote, parent, false);

        Pacote pacote = pacotes.get(posicao);

        configuraTextView(viewInflate, R.id.item_pacote_local, pacote.getLocal());
        configuraImageView(viewInflate, pacote);
        mostraDia(viewInflate, pacote);
        mostraPreco(viewInflate, pacote);

        return viewInflate;
    }

    private void mostraPreco(View viewInflate, Pacote pacote) {
        NumberFormat format = DecimalFormat.getCurrencyInstance(new Locale("pt", "br"));
        String moeda = format.format(pacote.getPreco()).replace("R$", "R$ ");
        configuraTextView(viewInflate, R.id.item_pacote_preco, moeda);
    }

    private void mostraDia(View viewInflate, Pacote pacote) {
        int qtdDias = pacote.getDias();
        String diaTexto = "";
        if(qtdDias > 1)
            diaTexto = qtdDias + " dias";
        else
            diaTexto = qtdDias + " dia";
        configuraTextView(viewInflate, R.id.item_pacote_dias, diaTexto);
    }

    private void configuraImageView(View viewInflate, Pacote pacote) {
        ((ImageView)viewInflate.findViewById(R.id.item_pacote_image))
                .setImageDrawable(context.getResources()
                    .getDrawable(context.getResources()
                        .getIdentifier(pacote.getImagem(), "drawable", context.getPackageName())));
    }

    private void configuraTextView(View viewInflate, int p, String local) {
        ((TextView) viewInflate.findViewById(p)).setText(local);
    }
}
