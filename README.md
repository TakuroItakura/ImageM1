- 左の画像をクリックすると雑草かどうか判定し結果が中央下に表示されます。
- 全体の処理の流れ
  1. z値で二値化したマスクを作ります。
  2. Dissimilalityで二値化したマスクを作ります(作り方は下で説明しています)。
  3. 1, 2のマスクをand演算してtrueなら雑草です。
- Dissimilalityでの二値化の流れ
  1. 対象ピクセルの周囲11x11を切り取ります。端は周囲がないので自動的にfalseにします。
  2. 切り取った画像をグレースケール化します。RGBのGを16段階に変換して、グレースケール化します。
  3. グレースケール画像からGLCM(Gray-Level Co-occurrence Matrix)を作ります。
  4. GLCMからDissimilalityを計算します。
  5. 事前に計算しておいた雑草と牧草のそれぞれのDissimilalityと比較して、雑草の方が近ければそのピクセルは雑草とします。
- 高速化について
  - `CalcGLCM()`の中のforループは小さいループを外に持っていくことでループ変数へのアクセス回数を減らして高速化しています(画像全体で0.2秒の高速化)
  - Homogeneity,ASMでの同様の処理をできるようにし、画像内をポチポチ押したときの実行時間をみたところHomogeneityが優れているようなので、全体に二値化するときにはHomogeneityを利用するようにしました。
