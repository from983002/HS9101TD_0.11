using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace Pattern_Modules
{
    public class Control_Measurement
    {
        /// <summary>
        /// 클래스 생성자 함수
        /// </summary>
        public Control_Measurement()
        {
            GetSetDivQuentity = 5;
        }
        /// <summary>
        /// 외부에서 이미지 분할 개수를 설정하는 함수
        /// </summary>
        public int GetSetDivQuentity { get; set; }

        /// <summary>
        /// 가로 ROI 이미지를 받아서 엣지 위치를 분석해 준다.
        /// </summary>
        /// 리턴 findResult : 
        public List<int> Garo_ROI_Process_Parallel(IplImage sourceImg)
        {
            
            IplImage srcImg = new IplImage(sourceImg.Size, sourceImg.Depth, sourceImg.NChannels);
            Cv.Copy(sourceImg, srcImg);
            var divImage = new Control_ImageROI();

            var divImages = divImage.Img_Deivde_Garo_Parallel(srcImg, GetSetDivQuentity);

            var findResult = new List<int>();
            foreach (var divImg in divImages)
            {
                var proj = new Control_Projection();
                List<int> divResult = proj.Projection_Garo_Parallel(divImg);
                findResult.Add(divResult[0]);
                findResult.Add(divResult[1]);
            }

            return findResult;

            divImages[0].DrawCircle(findResult[0], divImages[0].Height / 2, 3, CvColor.Red, 2);
            divImages[0].DrawCircle(findResult[1], divImages[0].Height / 2, 3, CvColor.Red, 2);
            //pictureBoxIpl1.ImageIpl = divImages[0];

            divImages[1].DrawCircle(findResult[2], divImages[1].Height / 2, 3, CvColor.Red, 2);
            divImages[1].DrawCircle(findResult[3], divImages[1].Height / 2, 3, CvColor.Red, 2);
            //pictureBoxIpl2.ImageIpl = divImages[1];

            divImages[2].DrawCircle(findResult[4], divImages[2].Height / 2, 3, CvColor.Red, 2);
            divImages[2].DrawCircle(findResult[5], divImages[2].Height / 2, 3, CvColor.Red, 2);
            //pictureBoxIpl3.ImageIpl = divImages[2];

            divImages[3].DrawCircle(findResult[6], divImages[3].Height / 2, 3, CvColor.Red, 2);
            divImages[3].DrawCircle(findResult[7], divImages[3].Height / 2, 3, CvColor.Red, 2);
            //pictureBoxIpl4.ImageIpl = divImages[3];

            divImages[4].DrawCircle(findResult[8], divImages[4].Height / 2, 3, CvColor.Red, 2);
            divImages[4].DrawCircle(findResult[9], divImages[4].Height / 2, 3, CvColor.Red, 2);
            //pictureBoxIpl5.ImageIpl = divImages[4];

            return findResult;
        }

        /// <summary>
        /// 세로 ROI 이미지를 받아서 엣지 위치를 분석해 준다.
        /// </summary>
        public List<int> Sero_ROI_Process_Parallel(IplImage sourceImg)
        {
            IplImage srcImg = new IplImage(sourceImg.Size, sourceImg.Depth, sourceImg.NChannels);
            Cv.Copy(sourceImg, srcImg);
            var divImage = new Control_ImageROI();

            var divImages = divImage.Img_Deivde_Sero_Parallel(srcImg, GetSetDivQuentity);

            var findResult = new List<int>();
            foreach (var divImg in divImages)
            {
                var proj = new Control_Projection();
                List<int> divResult = proj.Projection_Sero_Parallel(divImg);
                findResult.Add(divResult[0]);
                findResult.Add(divResult[1]);
            }

            return findResult;

            divImages[0].DrawCircle(divImages[0].Width / 2, findResult[0], 3, CvColor.Red, 2);
            divImages[0].DrawCircle(divImages[0].Width / 2, findResult[1], 3, CvColor.Red, 2);

            divImages[1].DrawCircle(divImages[1].Width / 2, findResult[2], 3, CvColor.Red, 2);
            divImages[1].DrawCircle(divImages[1].Width / 2, findResult[3], 3, CvColor.Red, 2);

            divImages[2].DrawCircle(divImages[2].Width / 2, findResult[4], 3, CvColor.Red, 2);
            divImages[2].DrawCircle(divImages[2].Width / 2, findResult[5], 3, CvColor.Red, 2);

            divImages[3].DrawCircle(divImages[3].Width / 2, findResult[6], 3, CvColor.Red, 2);
            divImages[3].DrawCircle(divImages[3].Width / 2, findResult[7], 3, CvColor.Red, 2);

            divImages[4].DrawCircle(divImages[4].Width / 2, findResult[8], 3, CvColor.Red, 2);
            divImages[4].DrawCircle(divImages[4].Width / 2, findResult[9], 3, CvColor.Red, 2);

            return findResult;
        }
    }
}
