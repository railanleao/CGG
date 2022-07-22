$(document).ready(function () {
    $('input[id="psbruto"]').blur(function () {
        var rendCarcaca = $(this).parent().parent().find('input[id="psbruto"]').first().val().replace('.', ',');
        rendCarcaca = rendCarcaca.replace(',', '.');
        var valorCalculado = (rendCarcaca * 50) / 100;
        var arroba = valorCalculado / 15;

        if (valorCalculado != 0 && arroba != 0)
        {
            $(this).parent().parent().find('input[id="rendCarc"]').first().val(valorCalculado.toFixed(2).replace('.',','));
            $(this).parent().parent().find('input[id="rendArroba"]').first().val(arroba.toFixed(2).replace('.', ','));
        }
        else
        {
            $(this).parent().find('input[id*="rendCarc"]').first().val('Valor Inválido');
        }
    });
});