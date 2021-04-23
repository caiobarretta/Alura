package br.com.alura.aluraviagens.util;

import java.text.SimpleDateFormat;
import java.util.Calendar;

public class DataUtil {

    public static final String PATTERN_DATA = "dd/MM";

    public static String periodoEmTexto(int dias) {
        Calendar dataIda = Calendar.getInstance();
        Calendar dataVolta = Calendar.getInstance();
        dataVolta.add(Calendar.DATE, dias);

        SimpleDateFormat dateFormatBr = new SimpleDateFormat(PATTERN_DATA);
        String dataFormatIda = dateFormatBr.format(dataIda.getTime());
        String dataFormatVolta = dateFormatBr.format(dataVolta.getTime());

        return String.format("%s - %s de %d", dataFormatIda, dataFormatVolta, dataVolta.get(Calendar.YEAR));
    }
}
