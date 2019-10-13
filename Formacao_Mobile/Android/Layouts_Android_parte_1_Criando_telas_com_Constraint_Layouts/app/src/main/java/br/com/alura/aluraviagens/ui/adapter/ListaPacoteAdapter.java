package br.com.alura.aluraviagens.ui.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

import br.com.alura.aluraviagens.R;
import br.com.alura.aluraviagens.model.Pacote;

public class ListaPacoteAdapter extends BaseAdapter {

    private final List<Pacote> pacotes;
    private Context context;

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

        ((TextView)viewInflate.findViewById(R.id.item_pacote_local)).setText(pacote.getLocal());

        ((ImageView)viewInflate.findViewById(R.id.item_pacote_image))
                .setImageDrawable(context.getResources()
                    .getDrawable(context.getResources()
                        .getIdentifier(pacote.getImagem(), "drawable", context.getPackageName())));

        ((TextView)viewInflate.findViewById(R.id.item_pacote_dias)).setText(pacote.getDias() + " dias");
        ((TextView)viewInflate.findViewById(R.id.item_pacote_preco)).setText("R$ " + pacote.getPreco());

        return viewInflate;
    }
}
