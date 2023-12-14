﻿using SixLabors.ImageSharp.Formats.Jpeg;

namespace services.tools.Image;

public class ImageOptimizer {
    public void ImageResizer(string inputImagePath, string outputImagePath, int? width, int? height) {
        var customWidth = width ?? 100;

        var customHeight = height ?? 100;

        using (var image = SixLabors.ImageSharp.Image.Load(inputImagePath)) {
            image.Mutate(x => x.Resize(customWidth, customHeight));

            image.Save(outputImagePath, new JpegEncoder {
                Quality = 100
            });
        }
    }
}