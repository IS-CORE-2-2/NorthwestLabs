var logo = document.getElementById("NWLlogo")

var animation3 = bodymovin.loadAnimation({
    container: logo,
    renderer: 'svg',
    loop: false,
    autoplay: true,
    prerender: true,
    path: '../Animations/NWLlogo.json'
})