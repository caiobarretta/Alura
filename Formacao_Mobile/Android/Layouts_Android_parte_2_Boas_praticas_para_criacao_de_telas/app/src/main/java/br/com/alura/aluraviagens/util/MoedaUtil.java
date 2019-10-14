package br.com.alura.aluraviagens.util;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.Locale;

public class MoedaUtil {

    public static final String PORTUGUES = "pt";
    public static final String BRASIL = "br";
    public static final String FORMATO_PADRAO = "R$";
    public static final String FORMATO_COM_ESPACOS = "R$ ";

    public static String formataMoeda(BigDecimal valor) {
        NumberFormat format = DecimalFormat.getCurrencyInstance(new Locale(PORTUGUES, BRASIL));
        return format.format(valor).replace(FORMATO_PADRAO, FORMATO_COM_ESPACOS);
    }
}
