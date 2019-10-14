package br.com.alura.aluraviagens.ui.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

import br.com.alura.aluraviagens.util.DiasUtil;
import br.com.alura.aluraviagens.util.MoedaUtil;
import br.com.alura.aluraviagens.R;
import br.com.alura.aluraviagens.util.ResourceUtil;
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

        mostraLocal(viewInflate, pacote);
        mostraImagem(viewInflate, pacote);
        mostraDia(viewInflate, pacote);
        mostraPreco(viewInflate, pacote);

        return viewInflate;
    }

    public void mostraLocal(View viewInflate, Pacote pacote){
        configuraTextView(viewInflate, R.id.item_pacote_local, pacote.getLocal());
    }

    public void mostraImagem(View viewInflate, Pacote pacote){
        configuraImageView(viewInflate, pacote);
    }

    private void mostraPreco(View viewInflate, Pacote pacote) {
        configuraTextView(viewInflate, R.id.item_pacote_preco, MoedaUtil.formataMoeda(pacote.getPreco()));
    }

    private void mostraDia(View viewInflate, Pacote pacote) {
        int qtdDias = pacote.getDias();
        String diaTexto = DiasUtil.formataEmTexto(qtdDias);
        configuraTextView(viewInflate, R.id.item_pacote_dias, diaTexto);
    }

    private void configuraImageView(View viewInflate, Pacote pacote) {
        ((ImageView)viewInflate.findViewById(R.id.item_pacote_image))
                .setImageDrawable(ResourceUtil.devolveDrawable(context, pacote.getImagem()));
    }


    private void configuraTextView(View viewInflate, int p, String local) {
        ((TextView) viewInflate.findViewById(p)).setText(local);
    }
}
