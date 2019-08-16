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
    getMaxGreyscaleRGBPixelValue(greyImage){
      var maxValue = 0
      for(var i = 0; i < greyImage.size; i++){
        var pixelVal = greyImage.getPixel(i)[0]
        if (pixelVal > maxValue){
          maxValue = pixelVal
        }
      }
      return maxValue
    },
    getMinGreyscaleRGBPixelValue(greyImage){
      var minValue = 255
      for(var i = 0; i < greyImage.size; i++){
        var pixelVal = greyImage.getPixel(i)[0]
        if (pixelVal < minValue){
          minValue = pixelVal
        }
      }
      return minValue
    },
    getBucketedGreyscaleRGBPixel(greyScaleRGBPixel,lowerCutoff, upperCutoff){
      if (greyScaleRGBPixel[0] < lowerCutoff){
        return [0]
      } else if (greyScaleRGBPixel[0] >= lowerCutoff && greyScaleRGBPixel[0] < upperCutoff){
        return [127]
      } else {
        return [255]
      }
    },
    bucketImage(greyImage){
      var minGreyScaleValue = this.getMinGreyscaleRGBPixelValue(greyImage)
      var maxGreyScaleValue = this.getMaxGreyscaleRGBPixelValue(greyImage)
      var lowerQuarterCutoff = ((minGreyScaleValue + maxGreyScaleValue)/4)
      var upperQuarterCutoff = ((minGreyScaleValue + maxGreyScaleValue)/4)*3
      var lowerThirdCutoff = ((minGreyScaleValue + maxGreyScaleValue)/3)
      var upperThirdCutoff = ((minGreyScaleValue + maxGreyScaleValue)/3)*2

      for(var i = 0; i < greyImage.size; i++){
        greyImage.setPixel(i, 
                        this.getBucketedGreyscaleRGBPixel(greyImage.getPixel(i),
                                                          lowerThirdCutoff,
                                                          upperThirdCutoff
                                                          )
                      )
      }
      return greyImage
    },
    threeValueViewDataURLBlurAndSinglePixelBucketingBased(imageJsImage){
      imageJsImage = imageJsImage.grey({mergeAlpha: true})
      imageJsImage = imageJsImage.gaussianFilter({
        radius: Math.ceil((imageJsImage.width + imageJsImage.height)*0.005),
        sigma: 1.5,
      })
      imageJsImage = this.bucketImage(imageJsImage)
      return imageJsImage.toDataURL()
    },
    threeValueViewDataURLHistogramBased(imageJsImage){
      imageJsImage = imageJsImage.grey({mergeAlpha: true})
      // vsr threeBucketHistogram = imageJsImage.getG
    },
    processedImg(){
      if(this.src == ''){
        return ''
      } else {
        Image.load(this.src).then((image) =>{
          this.pSrc = this.threeValueViewDataURLBlurAndSinglePixelBucketingBased(image)
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