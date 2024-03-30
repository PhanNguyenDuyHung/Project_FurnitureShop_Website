

   





//bổ sung
//const overcountModal = bootstrap.Modal.getOrCreateInstance('#overcount');
$('.count').keydown(function (e) {
    if (e.key == '-' || e.key == 'e') {
        return false;
    }
})
$('.count').keyup(function (e) {
    if (parseInt($(this).val()) == 0) {
        $(this).val(1)
    }

    if (parseInt($(this).val()) > parseInt($(this).attr('max'))) {
        $('#overcount').modal('toggle');
        $(this).val(1)
        return;
    }
})


function addNumber(num, id) {
  
    let quantityVal = document.getElementById(`item-quantity-value-${id}`);
    
    
    if (parseInt(quantityVal.value)+num < 1)
        return;

    if (parseInt(quantityVal.value) + num > parseInt($(`#item-quantity-value-${id}`).attr('max'))) {
        $('#overcount').modal('toggle');
        return;
    }

    quantityVal.value = parseInt(quantityVal.value) + num;

    let totalQuantityVal = document.getElementById(`item-total-price-${id}`);

    let price = parseFloat(document.getElementById(`price-number-${id}`).innerText.replace(/,/g, ''));
    
    totalQuantityVal.innerText = (price * parseInt(quantityVal.value)).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");

    //
    const allSelectBox = $(".select-box");
    let total = 0;
    for (let i = 1; i < allSelectBox.length; i++) {
        if (allSelectBox[i].checked) {
            const ma = allSelectBox[i].id.split("-")[2];
            total += parseFloat($(`#item-total-price-${ma}`).text().replace(/,/g, ''))
        }
    }
    $("#total").text(total.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
    
}
function onSelectAllChange() {
    const allSelectBox = $(".select-box");
    for (let i = 1; i < allSelectBox.length; i++) {
        allSelectBox[i].checked = allSelectBox[0].checked;
    }
    if (allSelectBox[0].checked) {
        const totalList = $(".item-price-total");
        
        
        let total = 0;
        for (let i = 0; i < totalList.length; i++) {
 
            total += parseFloat(totalList[i].innerText.replace(/,/g, ''))
        }
        console.log(total.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));

        $("#total").text(total.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
    }
    else
        $("#total").text(0);
}

function onSelectChange(x) {
    const currentSelectBox = $(`#select-item-${x}`);
    currentSelectBox.checked = !currentSelectBox.checked;

    const allSelectBox = $(".select-box");
    let total = 0;
    for (let i = 1; i < allSelectBox.length; i++) {
        if (allSelectBox[i].checked) {
            const ma = allSelectBox[i].id.split("-")[2];
            total += parseFloat($(`#item-total-price-${ma}`).text().replace(/,/g, ''))
        }
    }
    $("#total").text(total.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
    for (let i = 1; i < allSelectBox.length; i++) {
        if (!allSelectBox[i].checked) {
            allSelectBox[0].checked = false;
            return;
        }
           
    }
    allSelectBox[0].checked = true;
}
function checkout(makh) {

    const allSelectBox = $(".select-box");
    let noselection = true;
    for (let i = 1; i < allSelectBox.length; i++) {
        if (allSelectBox[i].checked) {
            noselection = false;
            break;
        }
    }
    if (noselection) return;
    const ngaytao = `${new Date().getFullYear()}-${new Date().getMonth() + 1}-${new Date().getDate()}`;
    const tinhtrang = 'Đang xử lý';
  
    const donhang = { ngaytao, tinhtrang, makh };
    const chitietdonhang = []
    for (let i = 1; i < allSelectBox.length; i++) {
        if (allSelectBox[i].checked) {
            const mactgh = allSelectBox[i].id.split("-")[2];
            
            const masp = parseInt($(`#item-masp-${mactgh}`).text());
            const soluong = parseInt($(`#item-quantity-value-${mactgh}`).val());
            const dongia = parseFloat($(`#price-number-${mactgh}`).text().replace(/,/g, ''))
            const mausac = $(`#item-color-${mactgh}`).text();
            const kichco = $(`#item-size-${mactgh}`).text();
            const thanhtien = parseFloat($(`#item-total-price-${mactgh}`).text().replace(/,/g, ''))
            chitietdonhang.push({ masp,soluong,dongia,mausac,kichco,thanhtien,mactgh: parseInt(mactgh) });
           
        }

    }
    donhang.chitietdonhang = chitietdonhang;
    $.ajax({
    type: 'POST',
    url: "/Giohang/checkout",
    data: JSON.stringify(donhang),
    contentType: "application/json",
    success: function (resultData) {
        alert("Thanh toán thành công!");
        window.location.href = `/Account/GetOrderByKhachHang?MaKH=${makh}`;
    },
    error: function (error) {
        alert("Có lỗi xảy ra trong quá trình thanh toán!");
        console.error(error);
    }
});
    
}




function openModal() {
    //show data
    const allSelectBox = $(".select-box");
    
    let noselection = true;
    for (let i = 1; i < allSelectBox.length; i++) {
        if (allSelectBox[i].checked) {
            noselection = false;
            break;
        }
    }
    if (noselection) return;
    const chitietdonhang = []
    for (let i = 1; i < allSelectBox.length; i++) {
        if (allSelectBox[i].checked) {
            const mactgh = allSelectBox[i].id.split("-")[2];
            const imgsrc = $(`#item-img-${mactgh}`).attr('src');
            const tensp = $(`#item-name-${mactgh}`).text();
            const soluong = parseInt($(`#item-quantity-value-${mactgh}`).val());
            
            const mausac = $(`#item-color-${mactgh}`).text();
            const kichco = $(`#item-size-${mactgh}`).text();
            const thanhtien = parseFloat($(`#item-total-price-${mactgh}`).text().replace(/,/g, ''))
            chitietdonhang.push({  tensp, imgsrc, soluong, mausac, kichco, thanhtien });

        }

    } 
    let innerHTML = ''
    for (let i = 0; i < chitietdonhang.length; i++) {
        innerHTML += ` <tr class="item-row">
                                       
                                        <td class="item-detail">
                                            <img class="item-img" style="height:35px;" src="${chitietdonhang[i].imgsrc}" alt="">
                                            <div clas="item-content">
                                                <div  class="title">${chitietdonhang[i].tensp}</div>
                                       
                                            </div>

                                        </td>
                                        <td class="item-properties">
                                            <div class="color">
                                                Màu sắc: <span>${chitietdonhang[i].mausac}</span>

                                            </div>
                                            <div class="color">
                                                Kích thước: <span >${chitietdonhang[i].kichco}</span>

                                            </div>
                                        </td>
                                       
                                        <td class="item-quantity">

                                            <div class="box-quantity">${chitietdonhang[i].soluong}</div>
                                        </td>
                                        <td class="item-total-price">

                                            <span class="item-price item-price-total">${chitietdonhang[i].thanhtien.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") }</span> VND

                                        </td>
                                       
                                    </tr>
`
    }

    innerHTML +=`<tr class="summary">
                                    <td style="font-weight: bold; text-align: right;" colspan="4">Tổng tiền: <span>${$(`#total`).text()}</span> VND</td>
                                </tr>`
    $(`#order-table`).html(innerHTML)

    //show modal
    $(`#checkout-modal`).addClass("fade show");
    $(`#checkout-modal`).css("display", "block");
    $(`#checkout-modal`).css("backdrop-filter", "blur(5px)");

    $(`#checkout-modal`).attr('aria-modal', true)
}
function closeModal() {
    $(`#checkout-modal`).removeClass("fade show");
    $(`#checkout-modal`).css("display", "none");
    $(`#checkout-modal`).attr('aria-modal', false)
}