<template>
  <label class="file-select">
    <input type="file" @change="handleFileChange"/>
    <br>
    <br>
    <img :src="src" width="800">
    <br>
    <br>
    <img :src="pSrc" width="800">
  </label>
</template>

<script>
import { Image } from 'image-js'

export default {
  name: 'ThreeValueViewCore',
  props: {
  },
  data(){
    return {
      src: '',
      pSrc: ''
    }
  },
  methods: {
    handleFileChange(e) {
      this.src = URL.createObjectURL(e.target.files[0])
      this.processedImg()
      console.log('hello')
    },
    getMaxGreyscaleRGBPixelValue(image){
      var maxValue = 0
      for(var i = 0; i < image.size; i++){
        var pixelVal = image.getPixel(i)[0]
        if (pixelVal > maxValue){
          maxValue = pixelVal
        }
      }
      return maxValue
    },
    getMinGreyscaleRGBPixelValue(image){
      var minValue = 255
      for(var i = 0; i < image.size; i++){
        var pixelVal = image.getPixel(i)[0]
        if (pixelVal < minValue){
          minValue = pixelVal
        }
      }
      return minValue

    },
    getBucketedGreyscaleRGBPixel(greyScaleRGBPixel, minGreyScaleValue, maxGreyScaleValue){
      var lowerQuarterCutoff = ((minGreyScaleValue + maxGreyScaleValue)/4)
      var upperQuarterCutoff = ((minGreyScaleValue + maxGreyScaleValue)/4)*3
      var lowerThirdCutoff = ((minGreyScaleValue + maxGreyScaleValue)/3)
      var upperThirdCutoff = ((minGreyScaleValue + maxGreyScaleValue)/3)*2
      
      if (greyScaleRGBPixel[0] < lowerThirdCutoff){
        return [0]
      } else if (greyScaleRGBPixel[0] >= lowerThirdCutoff && greyScaleRGBPixel[0] < upperThirdCutoff){
        return [127]
      } else {
        return [255]
      }
    },
    processedImg(){
      if(this.src == ''){
        return ''
      } else {
        Image.load(this.src).then((image) =>{
          console.log('[i] Greyscaling Image')
          var grey = image.grey({mergeAlpha: true})
          console.log('[i] Greyscaled Image')
          console.log('[i] Blurring Image')
          var blured = grey.blurFilter({radius: (((grey.width + grey.height)/2)/100)})
          console.log('[i] Blurred Image')
          console.log('[i] Resizing Image')
          var resized = blured.resize({width: grey.width/4, preserveAspectRatio: true})
          console.log('[i] Resized Image')
          console.log('[i] Getting Min Grey Value')
          var minGreyValue = this.getMinGreyscaleRGBPixelValue(resized)
          console.log('[i] Got Min Grey Value: ', minGreyValue)
          console.log('[i] Getting Max Grey Value')
          var maxGreyValue = this.getMaxGreyscaleRGBPixelValue(resized)
          console.log('[i] Got Max Grey Value:', maxGreyValue)
          console.log('[i] Bucketing Image')
          for(var i = 0; i < resized.size; i++){
            // console.log(resized.getPixel(i))
             resized.setPixel(i, 
                              this.getBucketedGreyscaleRGBPixel(resized.getPixel(i),
                                                                minGreyValue,
                                                                maxGreyValue
                                                              )
                            )
          }
          console.log('[i] Bucketed Image')
          // console.log('[i] Performing Secondary Blur on Image')
          // resized = resized.blurFilter({radius: 3})
          
          this.pSrc = resized.toDataURL()
          // var resized = 
          console.log('[i] Bucketed Pixel Values')
          // for
          // this.pSrc = resized.toDataURL()
          console.log(this.pSrc)
          
        })
        .catch((e) => {
          console.log('Failed to load image: ', e)
        })
    
      }
    },
    
  }
}
</script>

<style scoped>
</style>