from PIL import Image
import os

input_folder = "Assets\\braverse_data\images"
output_folder = "Assets\\braverse_data\images_png"

os.makedirs(output_folder, exist_ok = True)

for filename in os.listdir(input_folder):
    if filename.lower().endswith(".webp"):
        web_path = os.path.join(input_folder, filename)
        png_filename = os.path.splitext(filename)[0] + ".png"
        png_path = os.path.join(output_folder, png_filename)

        try:
            with Image.open(web_path) as img:
                img.save(png_path, "PNG")
            print(f"Converted: {filename} -> {png_filename}")
        except Exception as e:
            print(f"Failed to convert {filename}: {e}")

print("Conversion complete")