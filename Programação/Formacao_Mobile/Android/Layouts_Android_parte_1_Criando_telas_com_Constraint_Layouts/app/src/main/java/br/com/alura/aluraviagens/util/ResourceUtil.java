package br.com.alura.aluraviagens.util;

import android.content.Context;
import android.graphics.drawable.Drawable;

import br.com.alura.aluraviagens.model.Pacote;

public class ResourceUtil {

    public static final String DRAWABLE = "drawable";

    public static Drawable devolveDrawable(Context context, String drawableName) {
        return context.getResources()
                .getDrawable(context.getResources()
                        .getIdentifier(drawableName, DRAWABLE, context.getPackageName()));
    }
}
