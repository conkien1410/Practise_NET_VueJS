<script>
import Info from './components/Info.vue'
import TheWelcome from './components/TheWelcome.vue'


const routes = {
  '/': TheWelcome,
  '/info': Info
}

export default {
  data() {
    return {
      currentPath: window.location.hash
    }
  },
  computed: {
    currentView() {
      return routes[this.currentPath.slice(1) || '/'] || NotFound
    }
  },
  mounted() {
    window.addEventListener('hashchange', () => {
		  this.currentPath = window.location.hash
		})
  }
}

</script>

<template>
  <header>
    
    <!--<img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" />-->
    <nav>
      <a href="#/">TheWelcome</a>
      <a href="#/info">Info</a>
      <component :is="currentView" />

    </nav>
    
  </header>

  <main>
  </main>
</template>

<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
