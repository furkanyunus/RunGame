using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace Assets.Script
{
    public class YolPuan : MonoBehaviour
    {
        private float _gecenSure;
        public TextMeshProUGUI txtPuan;
        public bool sayacAcik = false;

        private void Start()
        {
            sayacAcik = true;
        }

        private void Update()
        {
            _gecenSure += Time.deltaTime;
            txtPuan.SetText(_gecenSure.ToString("0000"));
        }
    }
}
