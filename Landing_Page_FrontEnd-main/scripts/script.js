const listaPrincipal = document.querySelector('#list-products');
const listaCarrinho = document.querySelector('#cart-products');

let myJson = GetProdutos();

async function GetProdutos(){
  try {
    var response = await fetch('https://localhost:44309/SiteEcommerce/getcollection')
    var myJson = await response.json();

    PopularProdutos(myJson);

  } catch (error) {
    console.log(error)
  }
}

function PopularProdutos (myJson){
  
  if (listaCarrinho == null)
    listaPrincipal.innerHTML = ''
  else
    listaCarrinho.innerHTML = ''
  

  for (let index = 0; index < myJson.length; index++) {

    if (myJson[index].situacao){
      if (listaCarrinho == null){
        continue;
      }

      listaCarrinho.innerHTML += `<div id="card" class="card">
          <div class="img">
            <img src="${myJson[index].imagem}" alt="">
          </div>
          <div class="description">
            <h2>${myJson[index].descricao}</h2>
            <h3>R$ ${myJson[index].valor}</h3>
          </div>
          <div class="button">
            <input type="button" id="button" onclick="PatchProdutos('${myJson[index].id}')" value="Remover do carrinho">
          </div>
        </div>`
    }
    else{
      if (listaPrincipal == null){
        continue;
      }

      listaPrincipal.innerHTML += `<div id="card" class="card">
        <div class="img">
          <img src="${myJson[index].imagem}" alt="">
        </div>
        <div class="description">
          <h2>${myJson[index].descricao}</h2>
          <h3>R$ ${myJson[index].valor}</h3>
        </div>
        <div class="button">
          <input type="button" id="button" onclick="PatchProdutos('${myJson[index].id}')" value="Adicionar ao carrinho">
        </div>
      </div>`
    }
  }
}

async function PatchProdutos (id){
  try {
    if(id === null)
      return console.log("id nulo");

    const response = await fetch(`https://localhost:44309/SiteEcommerce/patch?id=${id}`, {
      method: "PATCH",
      headers: {
          "Content-Type" : "application/json"
        },
    });

    const listaAtualizada = await response.json();

    PopularProdutos(listaAtualizada);

    myJson = listaAtualizada;

  } catch (error) {
    console.log(error)
  }
}