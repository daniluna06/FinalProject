import { createGlobalStyle } from "styled-components";

export const GlobalStyle = createGlobalStyle`
    :root {
        --maxWidth: 1200px;
        --white: #fff;
        --lightGrey: #eee;
        --medGrey: #353535;
        --darkGrey: #1c1c1c;
        --fontSuperBig: 2.5rem;
        --fontBig: 1.5rem;
        --fontMed: 1.2rem;
        --fontSmall: 1rem;
    }

    * {
        box-sizing: border-box;
        font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', 'Roboto', 'Oxygen',
        'Ubuntu', 'Cantarell', 'Fira Sans', 'Droid Sans', 'Helvetica Neue', sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    body {
        margin: 0;
        padding: 0;
        min-height: 100vh;
	    background-color: #D3D3FF;
	    color:#36364e;
	    width: 90%;
	    margin: 0 auto;
    }
    
    nav {
        background-color: #f6a192;
        border-radius: 50px;
        margin-top: 20px;
    }

    nav ul {
        list-style: none;
        display: flex;
        justify-content: center;
        align-items: center;
        padding: 10px 0px;
    }

    nav ul li {
        background-color: white;
        height: 60px;
        margin: 0px 20px;
        border-radius: 50px;
    }

    nav a {
        height: 100%;
        padding: 0px 30px;
        border-radius: 30px;
        text-decoration: none;
        display: flex;
        align-items: center;
        color: black;
    }

    nav a:hover {
        background-color: #f6c492;
    }

    /* Main Content Styles */
    main {
        margin-top: 1rem;
    }

    .home-section {
        display: grid;
        grid-template: repeat(3, 1fr);
        text-align: center;
    }

    .home-section figure {
        margin-top: 1.5em;
        margin-right: 1em;
        float: left;
    }

    .home-section figure img {
        width: 100%;
        max-width: 300px;
        border-radius: 20px;
    }
        
    .home-section figure figcaption {
        padding-left: 1em;
        float: right;
    }

    /* Responsive Design */
    @media(max-width: 800px){
        /*remove nav menu*/
    }

    `
