package br.com.alura.aluraviagens.util;

public class DiasUtils {

    public static final String PLURAL = " dias";
    public static final String SINGULAR = " dia";

    public static String formataEmTexto(int qtdDias) {
        if(qtdDias > 1)
            return qtdDias + PLURAL;
        return qtdDias + SINGULAR;
    }
}
