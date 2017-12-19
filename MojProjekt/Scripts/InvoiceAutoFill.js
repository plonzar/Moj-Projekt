function calculatePriceWithTax() {
    let tax = document.getElementById('Tax').value;
    let priceWithoutTax = document.getElementById('PriceWithoutTax').value;

    priceWithoutTax = priceWithoutTax.replace(",", ".");
    let va = (Number(priceWithoutTax * (1 + (tax * 0.01)))).toFixed(2);
    //va = va.replace(".", ",");
    //priceWithoutTax = priceWithoutTax.replace(".", ",");

    document.getElementById('PriceWithoutTax').value = priceWithoutTax;
    document.getElementById('PriceWithTax').value = va;
}


function calculatePriceWithoutTax() {
    let tax = document.getElementById('Tax').value;
    let priceWithTax = document.getElementById('PriceWithTax').value;

    priceWithTax = priceWithTax.replace(",", ".");
    let va = (Number(priceWithTax) / Number(1 + (tax * 0.01))).toFixed(2);
    //va = va.replace(".", ",");
    //priceWithTax = priceWithTax.replace(".", ",");


    document.getElementById('PriceWithTax').value = priceWithTax;
    document.getElementById('PriceWithoutTax').value = va;
}

$(document).ready(function () {
    $("*[data-autocomplete-url]")
        .each(function () {
            $(this).autocomplete({
                source: $(this).data("autocomplete-url")
            });
        });
});