// giohang 
function changeQuantity(c){
    var quantity = parseInt(document.getElementById('quantity').value);
    if(c === '-'){
        document.getElementById('quantity').value = quantity - 1;
        if(quantity === 1){
            document.getElementById('quantity').value = 1;
        }
    }else{
        document.getElementById('quantity').value = quantity + 1;
    }
}

