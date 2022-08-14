<template>
  <div class="modal-overlay">
    <div class="modal">
      <slot name="header">
        Hello Wolrd Header
      </slot>

      <slot name="body">
        Hello Mars Body
      </slot>

      <slot name="footer">
        Hello Europa Footer
      </slot>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'Modal',
    methods: {
      close() {
        this.$emit('close');
      },
    },
  };
</script>


